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
    public class P041_SEL_PROC_DB_SELECT_1_Query1 : QueryBasis<P041_SEL_PROC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EPA.NUM_CONTRATO_APOL
            ,EPA.COD_PRODUTO
            ,EPA.COD_COBERTURA
            ,EPA.DTH_INI_VIGENCIA
            ,EPA.NUM_RAMO_CONTABIL
            ,EPA.COD_PRODUTO_ACESS
            ,EPA.COD_COBERTURA_ACESS
            ,EPA.NUM_APOLICE
            ,EPA.DTH_FIM_VIGENCIA
            ,EA.NUM_APOLICE
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
            :WS-DTH-FIM-VIGENCIA-NULL ,
            :EF148-NUM-APOLICE-EF
            FROM SEGUROS.EF_PROD_ACESSORIO EPA ,
            SEGUROS.EF_APOLICE EA
            WHERE EPA.NUM_APOLICE = :EF148-NUM-APOLICE
            AND EPA.COD_PRODUTO_ACESS = :EF148-COD-PRODUTO-ACESS
            AND :EF148-DTH-INI-VIGENCIA
            BETWEEN EPA.DTH_INI_VIGENCIA
            AND EPA.DTH_FIM_VIGENCIA
            AND EA.NUM_CONTRATO = EPA.NUM_CONTRATO_APOL
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT EPA.NUM_CONTRATO_APOL
											,EPA.COD_PRODUTO
											,EPA.COD_COBERTURA
											,EPA.DTH_INI_VIGENCIA
											,EPA.NUM_RAMO_CONTABIL
											,EPA.COD_PRODUTO_ACESS
											,EPA.COD_COBERTURA_ACESS
											,EPA.NUM_APOLICE
											,EPA.DTH_FIM_VIGENCIA
											,EA.NUM_APOLICE
											FROM SEGUROS.EF_PROD_ACESSORIO EPA 
							,
											SEGUROS.EF_APOLICE EA
											WHERE EPA.NUM_APOLICE = '{this.EF148_NUM_APOLICE}'
											AND EPA.COD_PRODUTO_ACESS = '{this.EF148_COD_PRODUTO_ACESS}'
											AND '{this.EF148_DTH_INI_VIGENCIA}'
											BETWEEN EPA.DTH_INI_VIGENCIA
											AND EPA.DTH_FIM_VIGENCIA
											AND EA.NUM_CONTRATO = EPA.NUM_CONTRATO_APOL
											FETCH FIRST 1 ROW ONLY
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
        public string EF148_NUM_APOLICE_EF { get; set; }

        public static P041_SEL_PROC_DB_SELECT_1_Query1 Execute(P041_SEL_PROC_DB_SELECT_1_Query1 p041_SEL_PROC_DB_SELECT_1_Query1)
        {
            var ths = p041_SEL_PROC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P041_SEL_PROC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P041_SEL_PROC_DB_SELECT_1_Query1();
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
            dta.EF148_NUM_APOLICE_EF = result[i++].Value?.ToString();
            return dta;
        }

    }
}