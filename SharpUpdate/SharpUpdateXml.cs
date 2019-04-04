using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace SharpUpdate
{
    /// Contains update information
    public class SharpUpdateXml
    {
        /// The update version #
        public Version Version { get; }

        /// The location of the update binary
        public Uri Uri { get; }

        /// The file path of the binary
        /// for use on local computer
        public string FilePath { get; }

        /// The MD5 of the update's binary
        public string MD5 { get; }

        /// The update's description
        public string Description { get; }

        /// The arguments to pass to the updated application on startup
        public string LaunchArgs { get; }

        /// Tag to distinguish types of updates
        public JobType Tag;

        /// Creates a new SharpUpdateXml object
        public SharpUpdateXml(Version version, Uri uri, string filePath, string md5, string description, string launchArgs, JobType t)
        {
            Version = version;
            Uri = uri;
            FilePath = filePath;
            MD5 = md5;
            Description = description;
            LaunchArgs = launchArgs;
            Tag = t;
        }

        /// Checks if update's version is newer than the old version
        public bool IsNewerThan(Version version)
        {
            return Version > version;
        }

        /// Checks the Uri to make sure file exist
        public static bool ExistsOnServer(Uri location)
        {
            if (location.ToString().StartsWith("file"))
            {
                return System.IO.File.Exists(location.LocalPath);
            }
            else
            {
                try
                {
                    // Request the update.xml
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                    // Read for response
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    resp.Close();

                    return resp.StatusCode == HttpStatusCode.OK;
                }
                catch { return false; }
            }
        }

        /// Parses the update.xml into SharpUpdateXml object
        public static SharpUpdateXml[] Parse(Uri location)
        {
            List<SharpUpdateXml> result = new List<SharpUpdateXml>();
            Version version = null;
            string url = "", filePath = "", md5 = "", description = "", launchArgs = "";

            try
            {
                // Load the document
				ServicePointManager.ServerCertificateValidationCallback = (s, ce, ch, ssl) => true;
				XmlDocument doc = new XmlDocument();
				doc.Load(location.AbsoluteUri);

                // Gets the appId's node with the update info
                XmlNodeList updateNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/update");
                foreach (XmlNode updateNode in updateNodes)
                {
                    // If the node doesn't exist, there is no update
                    if (updateNode == null)
                        return null;

                    // Parse data
                    version = Version.Parse(updateNode["version"].InnerText);
                    url = updateNode["url"].InnerText;
                    filePath = updateNode["filePath"].InnerText;
                    md5 = updateNode["md5"].InnerText;
                    description = updateNode["description"].InnerText;
                    launchArgs = updateNode["launchArgs"].InnerText;

                    result.Add(new SharpUpdateXml(version, new Uri(url), filePath, md5, description, launchArgs, JobType.UPDATE));
                }

                XmlNodeList addNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/add");
                foreach (XmlNode addNode in addNodes)
                {
                    // If the node doesn't exist, there is no add
                    if (addNode == null)
                        return null;

                    // Parse data
                    version = Version.Parse(addNode["version"].InnerText);
                    url = addNode["url"].InnerText;
                    filePath = addNode["filePath"].InnerText;
                    md5 = addNode["md5"].InnerText;
                    description = addNode["description"].InnerText;
                    launchArgs = addNode["launchArgs"].InnerText;

                    result.Add(new SharpUpdateXml(version, new Uri(url), filePath, md5, description, launchArgs, JobType.ADD));
                }

                XmlNodeList removeNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/remove");
                foreach (XmlNode removeNode in removeNodes)
                {
                    // If the node doesn't exist, there is no remove
                    if (removeNode == null)
                        return null;

                    // Parse data
                    filePath = removeNode["filePath"].InnerText;
                    description = removeNode["description"].InnerText;
                    launchArgs = removeNode["launchArgs"].InnerText;

                    result.Add(new SharpUpdateXml(null, null, filePath, null, description, launchArgs, JobType.REMOVE));
                }

                return result.ToArray();
            }
			catch { return null; }
        }
    }
}
