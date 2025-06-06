using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_ITEM,
            OCORR_HISTORICO
            , DATA_INIVIGENCIA
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO
            , :SEGURVGA-DATA-INIVIGENCIA
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO =
            :SEGURVGA-NUM-CERTIFICADO
            AND TIPO_SEGURADO =
            :SEGURVGA-TIPO-SEGURADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
											, DATA_INIVIGENCIA
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO =
											'{this.SEGURVGA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO =
											'{this.SEGURVGA_TIPO_SEGURADO}'
											WITH UR";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_TIPO_SEGURADO { get; set; }

        public static R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1 Execute(R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1 r0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}