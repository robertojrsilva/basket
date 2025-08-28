using BasketBackend.Controllers;
using BasketBackend.Models;
using Microsoft.AspNetCore.Components.Web;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BasketBackend.Services.Data
{
    /// <summary>
    /// Service for data manipulation - Get and Save
    /// </summary>
    public class DataService
    {
        private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        private readonly ILogger<DataService> _logger;

        /// <summary>
        /// Data Service constructor
        /// </summary>
        public DataService(ILogger<DataService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Data from an entity file
        /// </summary>
        /// <returns>File string file contents, otherwise empty.</returns>
        public virtual string GetData(string entity)
        {
            string readContents = "";

            try
            {
                using (StreamReader streamReader = new StreamReader(string.Format(@".\Data\{0}.json", entity), Encoding.UTF8))
                {
                    readContents = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get data!");
            }

            return readContents;
        }

        /// <summary>
        /// Save object Data to an entity file
        /// </summary>
        /// <returns>Save or not a string file contents.</returns>
        public virtual bool SaveData(object obj, string entity)
        {
            bool result = false;
            try
            {
                var options = new JsonSerializerOptions(_options)
                {
                    WriteIndented = true
                };

                List<object> objects = JsonSerializer.Deserialize<List<object>>(GetData(entity));
                objects.Add(obj);

                var jsonString = JsonSerializer.Serialize(objects, options);

                File.WriteAllText(string.Format(@".\Data\{0}.json", entity), jsonString);

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, "Failed to save data!");
            }

            return result;
        }
    }
}
