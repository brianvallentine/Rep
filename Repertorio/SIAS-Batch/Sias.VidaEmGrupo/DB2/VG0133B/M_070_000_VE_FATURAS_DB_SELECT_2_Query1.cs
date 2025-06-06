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
    public class M_070_000_VE_FATURAS_DB_SELECT_2_Query1 : QueryBasis<M_070_000_VE_FATURAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_REFERENCIA
            INTO
            :FDATA-REFERENCIA
            FROM
            SEGUROS.V1FATURCONT
            WHERE
            NUM_APOLICE = :R-NUM-APOLICE AND
            COD_SUBGRUPO = :FCOD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_REFERENCIA
											FROM
											SEGUROS.V1FATURCONT
											WHERE
											NUM_APOLICE = '{this.R_NUM_APOLICE}' AND
											COD_SUBGRUPO = '{this.FCOD_SUBGRUPO}'";

            return query;
        }
        public string FDATA_REFERENCIA { get; set; }
        public string R_NUM_APOLICE { get; set; }
        public string FCOD_SUBGRUPO { get; set; }

        public static M_070_000_VE_FATURAS_DB_SELECT_2_Query1 Execute(M_070_000_VE_FATURAS_DB_SELECT_2_Query1 m_070_000_VE_FATURAS_DB_SELECT_2_Query1)
        {
            var ths = m_070_000_VE_FATURAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_070_000_VE_FATURAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_070_000_VE_FATURAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.FDATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}