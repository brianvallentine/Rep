using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_070_000_VE_FATURAS_DB_SELECT_3_Query1 : QueryBasis<M_070_000_VE_FATURAS_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_FATURA
            INTO
            :NUM-FATURA
            FROM
            SEGUROS.V1FATURAS
            WHERE
            NUM_APOLICE = :R-NUM-APOLICE AND
            COD_SUBGRUPO = :FCOD-SUBGRUPO AND
            NUM_FATURA = :NUM-FATURA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_FATURA
											FROM
											SEGUROS.V1FATURAS
											WHERE
											NUM_APOLICE = '{this.R_NUM_APOLICE}' AND
											COD_SUBGRUPO = '{this.FCOD_SUBGRUPO}' AND
											NUM_FATURA = '{this.NUM_FATURA}'";

            return query;
        }
        public string NUM_FATURA { get; set; }
        public string R_NUM_APOLICE { get; set; }
        public string FCOD_SUBGRUPO { get; set; }

        public static M_070_000_VE_FATURAS_DB_SELECT_3_Query1 Execute(M_070_000_VE_FATURAS_DB_SELECT_3_Query1 m_070_000_VE_FATURAS_DB_SELECT_3_Query1)
        {
            var ths = m_070_000_VE_FATURAS_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_070_000_VE_FATURAS_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_070_000_VE_FATURAS_DB_SELECT_3_Query1();
            var i = 0;
            dta.NUM_FATURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}