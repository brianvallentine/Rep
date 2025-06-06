using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1 : QueryBasis<R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA
            INTO :SUBGVGAP-COD-CLIENTE,
            :SUBGVGAP-DATA-INIVIGENCIA,
            :SUBGVGAP-DATA-TERVIGENCIA
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_DATA_TERVIGENCIA { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1 Execute(R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1 r8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1)
        {
            var ths = r8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SUBGVGAP_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}