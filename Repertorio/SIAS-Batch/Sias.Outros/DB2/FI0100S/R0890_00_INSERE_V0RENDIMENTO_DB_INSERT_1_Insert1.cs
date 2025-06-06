using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1 : QueryBasis<R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RENDIMENTO
            VALUES (:V1FAVO-CODFAV,
            :V1FAVO-NUMREC,
            :V0REND-DATRDT,
            :V0REND-VALRDT,
            :V2FAVO-IDECBT,
            :V0REND-CODSVI,
            :V0REND-CODEMP,
            CURRENT TIMESTAMP,
            :V0REND-SITUACAO,
            :V1FONT-FONTE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RENDIMENTO VALUES ({FieldThreatment(this.V1FAVO_CODFAV)}, {FieldThreatment(this.V1FAVO_NUMREC)}, {FieldThreatment(this.V0REND_DATRDT)}, {FieldThreatment(this.V0REND_VALRDT)}, {FieldThreatment(this.V2FAVO_IDECBT)}, {FieldThreatment(this.V0REND_CODSVI)}, {FieldThreatment(this.V0REND_CODEMP)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0REND_SITUACAO)}, {FieldThreatment(this.V1FONT_FONTE)})";

            return query;
        }
        public string V1FAVO_CODFAV { get; set; }
        public string V1FAVO_NUMREC { get; set; }
        public string V0REND_DATRDT { get; set; }
        public string V0REND_VALRDT { get; set; }
        public string V2FAVO_IDECBT { get; set; }
        public string V0REND_CODSVI { get; set; }
        public string V0REND_CODEMP { get; set; }
        public string V0REND_SITUACAO { get; set; }
        public string V1FONT_FONTE { get; set; }

        public static void Execute(R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1 r0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}