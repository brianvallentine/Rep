using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0001S
{
    public class R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCTCOT,
            PCTCTF,
            PCTDNO,
            PCTCOMCO,
            DTCUTOFF,
            RECUP_PSL,
            COD_CONTRATO_RE
            INTO :V0DRES-PCTCOT,
            :V0DRES-PCTCTF,
            :V0DRES-PCTDNO,
            :V0DRES-PCTCOMCO,
            :V0DRES-DTCUTOFF:VIND-DTCUTOFF,
            :V0DRES-RECUP-PSL,
            :V0DRES-CONTR-RESG:VIND-CONTR-RE
            FROM SEGUROS.V0DADOSRES
            WHERE RAMO = :WHOST-RAMOFR
            AND MODALIDA = :WHOST-MODALIFR
            AND DTINIVIG <= :WHOST-DTINIVIG
            AND DTTERVIG >= :WHOST-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCTCOT
							,
											PCTCTF
							,
											PCTDNO
							,
											PCTCOMCO
							,
											DTCUTOFF
							,
											RECUP_PSL
							,
											COD_CONTRATO_RE
											FROM SEGUROS.V0DADOSRES
											WHERE RAMO = '{this.WHOST_RAMOFR}'
											AND MODALIDA = '{this.WHOST_MODALIFR}'
											AND DTINIVIG <= '{this.WHOST_DTINIVIG}'
											AND DTTERVIG >= '{this.WHOST_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V0DRES_PCTCOT { get; set; }
        public string V0DRES_PCTCTF { get; set; }
        public string V0DRES_PCTDNO { get; set; }
        public string V0DRES_PCTCOMCO { get; set; }
        public string V0DRES_DTCUTOFF { get; set; }
        public string VIND_DTCUTOFF { get; set; }
        public string V0DRES_RECUP_PSL { get; set; }
        public string V0DRES_CONTR_RESG { get; set; }
        public string VIND_CONTR_RE { get; set; }
        public string WHOST_MODALIFR { get; set; }
        public string WHOST_DTINIVIG { get; set; }
        public string WHOST_RAMOFR { get; set; }

        public static R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1 r0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_V0DADOSRES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0DRES_PCTCOT = result[i++].Value?.ToString();
            dta.V0DRES_PCTCTF = result[i++].Value?.ToString();
            dta.V0DRES_PCTDNO = result[i++].Value?.ToString();
            dta.V0DRES_PCTCOMCO = result[i++].Value?.ToString();
            dta.V0DRES_DTCUTOFF = result[i++].Value?.ToString();
            dta.VIND_DTCUTOFF = string.IsNullOrWhiteSpace(dta.V0DRES_DTCUTOFF) ? "-1" : "0";
            dta.V0DRES_RECUP_PSL = result[i++].Value?.ToString();
            dta.V0DRES_CONTR_RESG = result[i++].Value?.ToString();
            dta.VIND_CONTR_RE = string.IsNullOrWhiteSpace(dta.V0DRES_CONTR_RESG) ? "-1" : "0";
            return dta;
        }

    }
}