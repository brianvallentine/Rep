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
    public class R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1 : QueryBasis<R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMPDT,
            NUMREC,
            TPPESSOA,
            INSPREFE,
            INSINPS,
            CGCCPF,
            DCOIRF,
            CEP
            INTO :V1FAVO-NOMFAV,
            :V1FAVO-NUMREC,
            :V1FAVO-TPPESSOA,
            :V1FAVO-INSPREFE,
            :V1FAVO-INSINPS,
            :V1FAVO-CGCCPF,
            :V1FAVO-DCOIRF,
            :V1FAVO-CEP
            FROM SEGUROS.V1PRODUTOR
            WHERE CODPDT = :V1FAVO-CODFAV
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMPDT
							,
											NUMREC
							,
											TPPESSOA
							,
											INSPREFE
							,
											INSINPS
							,
											CGCCPF
							,
											DCOIRF
							,
											CEP
											FROM SEGUROS.V1PRODUTOR
											WHERE CODPDT = '{this.V1FAVO_CODFAV}'";

            return query;
        }
        public string V1FAVO_NOMFAV { get; set; }
        public string V1FAVO_NUMREC { get; set; }
        public string V1FAVO_TPPESSOA { get; set; }
        public string V1FAVO_INSPREFE { get; set; }
        public string V1FAVO_INSINPS { get; set; }
        public string V1FAVO_CGCCPF { get; set; }
        public string V1FAVO_DCOIRF { get; set; }
        public string V1FAVO_CEP { get; set; }
        public string V1FAVO_CODFAV { get; set; }

        public static R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1 Execute(R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1 r0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1)
        {
            var ths = r0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FAVO_NOMFAV = result[i++].Value?.ToString();
            dta.V1FAVO_NUMREC = result[i++].Value?.ToString();
            dta.V1FAVO_TPPESSOA = result[i++].Value?.ToString();
            dta.V1FAVO_INSPREFE = result[i++].Value?.ToString();
            dta.V1FAVO_INSINPS = result[i++].Value?.ToString();
            dta.V1FAVO_CGCCPF = result[i++].Value?.ToString();
            dta.V1FAVO_DCOIRF = result[i++].Value?.ToString();
            dta.V1FAVO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}