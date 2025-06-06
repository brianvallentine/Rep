using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1 : QueryBasis<M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            INTO :PROPOVA-NUM-CERTIFICADO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO
            AND COD_CLIENTE = :SUBGVGAP-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.VGSOLFAT_COD_SUBGRUPO}'
											AND COD_CLIENTE = '{this.SUBGVGAP_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }

        public static M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1 Execute(M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1 m_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1)
        {
            var ths = m_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}