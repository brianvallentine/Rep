using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE,
            NUM_ITEM,
            MODALIDA,
            RAMO
            INTO
            :V0NUM-APOLICE,
            :SNUM-ITEM:WNUM-ITEM,
            :V0APOL-MODALIDA,
            :V0APOL-RAMO
            FROM
            SEGUROS.V0APOLICE
            WHERE
            NUM_APOLICE = :MNUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											NUM_ITEM
							,
											MODALIDA
							,
											RAMO
											FROM
											SEGUROS.V0APOLICE
											WHERE
											NUM_APOLICE = '{this.MNUM_APOLICE}'";

            return query;
        }
        public string V0NUM_APOLICE { get; set; }
        public string SNUM_ITEM { get; set; }
        public string WNUM_ITEM { get; set; }
        public string V0APOL_MODALIDA { get; set; }
        public string V0APOL_RAMO { get; set; }
        public string MNUM_APOLICE { get; set; }

        public static M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1 Execute(M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1 m_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0NUM_APOLICE = result[i++].Value?.ToString();
            dta.SNUM_ITEM = result[i++].Value?.ToString();
            dta.WNUM_ITEM = string.IsNullOrWhiteSpace(dta.SNUM_ITEM) ? "-1" : "0";
            dta.V0APOL_MODALIDA = result[i++].Value?.ToString();
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}