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
    public class R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1 : QueryBasis<R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0IMPOSTOS
            VALUES (:V1FAVO-CODFAV,
            :V1FAVO-NUMREC,
            :V0IMPO-DATIPT,
            :V0IMPO-TIPIPT,
            :V0IMPO-VALIPT,
            :V2FAVO-IDECBT,
            :V0IMPO-CODSVI,
            :V0IMPO-CODEMP,
            CURRENT TIMESTAMP,
            :V0IMPO-SITUACAO,
            :V1FONT-FONTE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0IMPOSTOS VALUES ({FieldThreatment(this.V1FAVO_CODFAV)}, {FieldThreatment(this.V1FAVO_NUMREC)}, {FieldThreatment(this.V0IMPO_DATIPT)}, {FieldThreatment(this.V0IMPO_TIPIPT)}, {FieldThreatment(this.V0IMPO_VALIPT)}, {FieldThreatment(this.V2FAVO_IDECBT)}, {FieldThreatment(this.V0IMPO_CODSVI)}, {FieldThreatment(this.V0IMPO_CODEMP)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0IMPO_SITUACAO)}, {FieldThreatment(this.V1FONT_FONTE)})";

            return query;
        }
        public string V1FAVO_CODFAV { get; set; }
        public string V1FAVO_NUMREC { get; set; }
        public string V0IMPO_DATIPT { get; set; }
        public string V0IMPO_TIPIPT { get; set; }
        public string V0IMPO_VALIPT { get; set; }
        public string V2FAVO_IDECBT { get; set; }
        public string V0IMPO_CODSVI { get; set; }
        public string V0IMPO_CODEMP { get; set; }
        public string V0IMPO_SITUACAO { get; set; }
        public string V1FONT_FONTE { get; set; }

        public static void Execute(R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1 r0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1)
        {
            var ths = r0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}