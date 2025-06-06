using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0135B
{
    public class R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1 : QueryBasis<R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0EMISDIARIA
            VALUES (:V0EDIA-CODRELAT ,
            :V0EDIA-NUM-APOL ,
            :V0EDIA-NRENDOS ,
            :V0EDIA-NRPARCEL ,
            :V0EDIA-DTMOVTO ,
            :V0EDIA-ORGAO ,
            :V0EDIA-RAMO ,
            :V0EDIA-FONTE ,
            :V0EDIA-CONGENER ,
            :V0EDIA-CODCORR ,
            :V0EDIA-SITUACAO ,
            :V0EDIA-COD-EMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EMISDIARIA VALUES ({FieldThreatment(this.V0EDIA_CODRELAT)} , {FieldThreatment(this.V0EDIA_NUM_APOL)} , {FieldThreatment(this.V0EDIA_NRENDOS)} , {FieldThreatment(this.V0EDIA_NRPARCEL)} , {FieldThreatment(this.V0EDIA_DTMOVTO)} , {FieldThreatment(this.V0EDIA_ORGAO)} , {FieldThreatment(this.V0EDIA_RAMO)} , {FieldThreatment(this.V0EDIA_FONTE)} , {FieldThreatment(this.V0EDIA_CONGENER)} , {FieldThreatment(this.V0EDIA_CODCORR)} , {FieldThreatment(this.V0EDIA_SITUACAO)} , {FieldThreatment(this.V0EDIA_COD_EMP)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0EDIA_CODRELAT { get; set; }
        public string V0EDIA_NUM_APOL { get; set; }
        public string V0EDIA_NRENDOS { get; set; }
        public string V0EDIA_NRPARCEL { get; set; }
        public string V0EDIA_DTMOVTO { get; set; }
        public string V0EDIA_ORGAO { get; set; }
        public string V0EDIA_RAMO { get; set; }
        public string V0EDIA_FONTE { get; set; }
        public string V0EDIA_CONGENER { get; set; }
        public string V0EDIA_CODCORR { get; set; }
        public string V0EDIA_SITUACAO { get; set; }
        public string V0EDIA_COD_EMP { get; set; }

        public static void Execute(R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1 r1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1)
        {
            var ths = r1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}