using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0705B
{
    public class R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_SUBGRUPO,
            COD_PRODUTO,
            DATA_MOVIMENTO,
            IDE_SEXO
            INTO :PROPOVA-NUM-APOLICE,
            :PROPOVA-COD-SUBGRUPO,
            :PROPOVA-COD-PRODUTO,
            :PROPOVA-DATA-MOVIMENTO,
            :PROPOVA-IDE-SEXO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											COD_PRODUTO
							,
											DATA_MOVIMENTO
							,
											IDE_SEXO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_DATA_MOVIMENTO { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 Execute(R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 r0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PROPOVA_IDE_SEXO = result[i++].Value?.ToString();
            return dta;
        }

    }
}