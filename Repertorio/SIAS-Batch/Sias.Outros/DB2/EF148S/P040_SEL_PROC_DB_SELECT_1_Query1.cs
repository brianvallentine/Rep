using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.EF148S
{
    public class P040_SEL_PROC_DB_SELECT_1_Query1 : QueryBasis<P040_SEL_PROC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CONTRATO_APOL
            , COD_PRODUTO
            , COD_COBERTURA
            , DTH_INI_VIGENCIA
            , NUM_RAMO_CONTABIL
            , COD_PRODUTO_ACESS
            , COD_COBERTURA_ACESS
            , NUM_APOLICE
            , DTH_FIM_VIGENCIA
            INTO
            :EF148-NUM-CONTRATO-APOL ,
            :EF148-COD-PRODUTO ,
            :EF148-COD-COBERTURA ,
            :EF148-DTH-INI-VIGENCIA ,
            :EF148-NUM-RAMO-CONTABIL ,
            :EF148-COD-PRODUTO-ACESS ,
            :EF148-COD-COBERTURA-ACESS ,
            :EF148-NUM-APOLICE ,
            :EF148-DTH-FIM-VIGENCIA
            :WS-DTH-FIM-VIGENCIA-NULL
            FROM SEGUROS.EF_PROD_ACESSORIO
            WHERE NUM_CONTRATO_APOL = :EF148-NUM-CONTRATO-APOL
            AND COD_PRODUTO = :EF148-COD-PRODUTO
            AND COD_COBERTURA = :EF148-COD-COBERTURA
            AND :EF148-DTH-INI-VIGENCIA
            BETWEEN DTH_INI_VIGENCIA
            AND DTH_FIM_VIGENCIA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CONTRATO_APOL
											, COD_PRODUTO
											, COD_COBERTURA
											, DTH_INI_VIGENCIA
											, NUM_RAMO_CONTABIL
											, COD_PRODUTO_ACESS
											, COD_COBERTURA_ACESS
											, NUM_APOLICE
											, DTH_FIM_VIGENCIA
											FROM SEGUROS.EF_PROD_ACESSORIO
											WHERE NUM_CONTRATO_APOL = '{this.EF148_NUM_CONTRATO_APOL}'
											AND COD_PRODUTO = '{this.EF148_COD_PRODUTO}'
											AND COD_COBERTURA = '{this.EF148_COD_COBERTURA}'
											AND '{this.EF148_DTH_INI_VIGENCIA}'
											BETWEEN DTH_INI_VIGENCIA
											AND DTH_FIM_VIGENCIA
											WITH UR";

            return query;
        }
        public string EF148_NUM_CONTRATO_APOL { get; set; }
        public string EF148_COD_PRODUTO { get; set; }
        public string EF148_COD_COBERTURA { get; set; }
        public string EF148_DTH_INI_VIGENCIA { get; set; }
        public string EF148_NUM_RAMO_CONTABIL { get; set; }
        public string EF148_COD_PRODUTO_ACESS { get; set; }
        public string EF148_COD_COBERTURA_ACESS { get; set; }
        public string EF148_NUM_APOLICE { get; set; }
        public string EF148_DTH_FIM_VIGENCIA { get; set; }
        public string WS_DTH_FIM_VIGENCIA_NULL { get; set; }

        public static P040_SEL_PROC_DB_SELECT_1_Query1 Execute(P040_SEL_PROC_DB_SELECT_1_Query1 p040_SEL_PROC_DB_SELECT_1_Query1)
        {
            var ths = p040_SEL_PROC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P040_SEL_PROC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P040_SEL_PROC_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF148_NUM_CONTRATO_APOL = result[i++].Value?.ToString();
            dta.EF148_COD_PRODUTO = result[i++].Value?.ToString();
            dta.EF148_COD_COBERTURA = result[i++].Value?.ToString();
            dta.EF148_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.EF148_NUM_RAMO_CONTABIL = result[i++].Value?.ToString();
            dta.EF148_COD_PRODUTO_ACESS = result[i++].Value?.ToString();
            dta.EF148_COD_COBERTURA_ACESS = result[i++].Value?.ToString();
            dta.EF148_NUM_APOLICE = result[i++].Value?.ToString();
            dta.EF148_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.WS_DTH_FIM_VIGENCIA_NULL = string.IsNullOrWhiteSpace(dta.EF148_DTH_FIM_VIGENCIA) ? "-1" : "0";
            return dta;
        }

    }
}