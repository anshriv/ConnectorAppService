// ---------------------------------------------------------------------------
// <copyright file="DataSourceMetadata.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomConnector.Controllers.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Metadata information of data source for a connection.
    /// </summary>
    [DataContract]
    public class DataSourceMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceMetadata"/> class.
        /// </summary>
        public DataSourceMetadata()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceMetadata"/> class.
        /// </summary>
        /// <param name="properties">dictionary of additional fields</param>
        public DataSourceMetadata(IDictionary<string, object> properties)
        {
            this.Properties = properties;
        }

        /// <summary>
        /// Datasource display name in a particular format specific to a connector.
        /// </summary>
        [DataMember]
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Additional Properties of the DataSource
        /// </summary>
        [DataMember]
        [JsonProperty("properties")]
        public IDictionary<string, object> Properties { get; set; }
    }
}
