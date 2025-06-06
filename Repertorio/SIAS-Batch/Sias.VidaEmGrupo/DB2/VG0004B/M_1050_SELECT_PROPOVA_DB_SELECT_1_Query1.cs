using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0004B
{
    public class M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1 : QueryBasis<M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTPROXVEN
            INTO :PROPOVA-DTPROXVEN
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE
            AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO
            AND NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTPROXVEN
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_APOLICE = '{this.HISCONPA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.HISCONPA_COD_SUBGRUPO}'
											AND NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }

        public static M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1 Execute(M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1 m_1050_SELECT_PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = m_1050_SELECT_PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}