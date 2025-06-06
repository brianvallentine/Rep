using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 : QueryBasis<R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(PRM_TARIFARIO),0),
            VALUE(SUM(VAL_DESCONTO),0),
            VALUE(SUM(PRM_LIQUIDO),0),
            VALUE(SUM(ADICIONAL_FRACIO),0),
            VALUE(SUM(VAL_CUSTO_EMISSAO),0),
            VALUE(SUM(VAL_IOCC),0),
            VALUE(SUM(PRM_TOTAL),0)
            INTO
            :WS-CM-PRM-TARIFARIO,
            :WS-CM-VAL-DESCONTO ,
            :WS-CM-PRM-LIQUIDO ,
            :WS-CM-ADICIONAL-FRACIO,
            :WS-CM-VAL-CUSTO-EMISSAO,
            :WS-CM-VAL-IOCC,
            :WS-CM-PRM-TOTAL
            FROM
            SEGUROS.PARCELA_HISTORICO
            WHERE
            NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA
            AND COD_OPERACAO = 0801
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO)
							,0)
							,
											VALUE(SUM(VAL_DESCONTO)
							,0)
							,
											VALUE(SUM(PRM_LIQUIDO)
							,0)
							,
											VALUE(SUM(ADICIONAL_FRACIO)
							,0)
							,
											VALUE(SUM(VAL_CUSTO_EMISSAO)
							,0)
							,
											VALUE(SUM(VAL_IOCC)
							,0)
							,
											VALUE(SUM(PRM_TOTAL)
							,0)
											FROM
											SEGUROS.PARCELA_HISTORICO
											WHERE
											NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCEHIS_NUM_PARCELA}'
											AND COD_OPERACAO = 0801";

            return query;
        }
        public string WS_CM_PRM_TARIFARIO { get; set; }
        public string WS_CM_VAL_DESCONTO { get; set; }
        public string WS_CM_PRM_LIQUIDO { get; set; }
        public string WS_CM_ADICIONAL_FRACIO { get; set; }
        public string WS_CM_VAL_CUSTO_EMISSAO { get; set; }
        public string WS_CM_VAL_IOCC { get; set; }
        public string WS_CM_PRM_TOTAL { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 Execute(R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 r2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CM_PRM_TARIFARIO = result[i++].Value?.ToString();
            dta.WS_CM_VAL_DESCONTO = result[i++].Value?.ToString();
            dta.WS_CM_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.WS_CM_ADICIONAL_FRACIO = result[i++].Value?.ToString();
            dta.WS_CM_VAL_CUSTO_EMISSAO = result[i++].Value?.ToString();
            dta.WS_CM_VAL_IOCC = result[i++].Value?.ToString();
            dta.WS_CM_PRM_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}