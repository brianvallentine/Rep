using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 : QueryBasis<S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0EMISDIARIA
            VALUES (:V1EDIA-CODRELAT ,
            :V1EDIA-NUMAPOL ,
            :V1EDIA-NRENDOS ,
            :V1EDIA-NRPARCEL ,
            :V1EDIA-DTMOVTO ,
            :V1EDIA-ORGAO ,
            :V1EDIA-RAMO ,
            :V1EDIA-FONTE ,
            :V1EDIA-CONGENER ,
            :V1EDIA-CODCORR ,
            :V1EDIA-SITUACAO ,
            :V1EDIA-COD-EMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EMISDIARIA VALUES ({FieldThreatment(this.V1EDIA_CODRELAT)} , {FieldThreatment(this.V1EDIA_NUMAPOL)} , {FieldThreatment(this.V1EDIA_NRENDOS)} , {FieldThreatment(this.V1EDIA_NRPARCEL)} , {FieldThreatment(this.V1EDIA_DTMOVTO)} , {FieldThreatment(this.V1EDIA_ORGAO)} , {FieldThreatment(this.V1EDIA_RAMO)} , {FieldThreatment(this.V1EDIA_FONTE)} , {FieldThreatment(this.V1EDIA_CONGENER)} , {FieldThreatment(this.V1EDIA_CODCORR)} , {FieldThreatment(this.V1EDIA_SITUACAO)} , {FieldThreatment(this.V1EDIA_COD_EMP)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V1EDIA_CODRELAT { get; set; }
        public string V1EDIA_NUMAPOL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }
        public string V1EDIA_NRPARCEL { get; set; }
        public string V1EDIA_DTMOVTO { get; set; }
        public string V1EDIA_ORGAO { get; set; }
        public string V1EDIA_RAMO { get; set; }
        public string V1EDIA_FONTE { get; set; }
        public string V1EDIA_CONGENER { get; set; }
        public string V1EDIA_CODCORR { get; set; }
        public string V1EDIA_SITUACAO { get; set; }
        public string V1EDIA_COD_EMP { get; set; }

        public static void Execute(S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 s3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1)
        {
            var ths = s3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override S3000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}