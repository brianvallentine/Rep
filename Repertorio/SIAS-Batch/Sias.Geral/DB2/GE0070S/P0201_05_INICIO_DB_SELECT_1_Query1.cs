using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0070S
{
    public class P0201_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0201_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            ,SEQ_PRODUTO_VRS
            ,DTA_INI_VIGENCIA
            ,DTA_FIM_VIGENCIA
            ,IND_FLUXO_PARAMTRIZADO
            ,COD_PERIOD_VIGENCIA
            ,QTD_PERIOD_VIGENCIA
            ,COD_MOEDA
            ,IND_RENOVA
            ,IND_RENOVA_AUTOMATICA
            ,QTD_RENOVA_AUTOMATICA
            ,IND_DPS
            ,IND_REENQUADRA_PREMIO
            ,IND_REAJUSTE_PREMIO
            ,COD_INDICE_REAJUSTE
            ,COD_PERIOD_REAJUSTE
            ,COD_INDICE_DEVOLUCAO
            ,PCT_JUROS_DEVOLUCAO
            ,PCT_MULTA_DEVOLUCAO
            ,IND_FLUXO_COMISSAO
            ,IND_ACOPLADO
            ,IND_FLUXO_SINISTRO
            ,IND_CONJUGE
            ,COD_USUARIO
            ,NOM_PROGRAMA
            ,CHAR(DTH_CADASTRAMENTO)
            INTO :GE089-COD-PRODUTO
            ,:GE089-SEQ-PRODUTO-VRS
            ,:GE089-DTA-INI-VIGENCIA
            ,:GE089-DTA-FIM-VIGENCIA
            ,:GE089-IND-FLUXO-PARAMTRIZADO
            ,:GE089-COD-PERIOD-VIGENCIA
            ,:GE089-QTD-PERIOD-VIGENCIA
            ,:GE089-COD-MOEDA
            ,:GE089-IND-RENOVA
            ,:GE089-IND-RENOVA-AUTOMATICA
            ,:GE089-QTD-RENOVA-AUTOMATICA
            ,:GE089-IND-DPS
            ,:GE089-IND-REENQUADRA-PREMIO
            ,:GE089-IND-REAJUSTE-PREMIO
            ,:GE089-COD-INDICE-REAJUSTE
            ,:GE089-COD-PERIOD-REAJUSTE
            ,:GE089-COD-INDICE-DEVOLUCAO
            ,:GE089-PCT-JUROS-DEVOLUCAO
            ,:GE089-PCT-MULTA-DEVOLUCAO
            ,:GE089-IND-FLUXO-COMISSAO
            ,:GE089-IND-ACOPLADO
            ,:GE089-IND-FLUXO-SINISTRO
            ,:GE089-IND-CONJUGE
            ,:GE089-COD-USUARIO
            ,:GE089-NOM-PROGRAMA
            ,:GE089-DTH-CADASTRAMENTO
            FROM SEGUROS.GE_PRODUTO_COMPLEMENTO
            WHERE COD_PRODUTO = :GE089-COD-PRODUTO
            AND SEQ_PRODUTO_VRS = :GE089-SEQ-PRODUTO-VRS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											,SEQ_PRODUTO_VRS
											,DTA_INI_VIGENCIA
											,DTA_FIM_VIGENCIA
											,IND_FLUXO_PARAMTRIZADO
											,COD_PERIOD_VIGENCIA
											,QTD_PERIOD_VIGENCIA
											,COD_MOEDA
											,IND_RENOVA
											,IND_RENOVA_AUTOMATICA
											,QTD_RENOVA_AUTOMATICA
											,IND_DPS
											,IND_REENQUADRA_PREMIO
											,IND_REAJUSTE_PREMIO
											,COD_INDICE_REAJUSTE
											,COD_PERIOD_REAJUSTE
											,COD_INDICE_DEVOLUCAO
											,PCT_JUROS_DEVOLUCAO
											,PCT_MULTA_DEVOLUCAO
											,IND_FLUXO_COMISSAO
											,IND_ACOPLADO
											,IND_FLUXO_SINISTRO
											,IND_CONJUGE
											,COD_USUARIO
											,NOM_PROGRAMA
											,CHAR(DTH_CADASTRAMENTO)
											FROM SEGUROS.GE_PRODUTO_COMPLEMENTO
											WHERE COD_PRODUTO = '{this.GE089_COD_PRODUTO}'
											AND SEQ_PRODUTO_VRS = '{this.GE089_SEQ_PRODUTO_VRS}'
											WITH UR";

            return query;
        }
        public string GE089_COD_PRODUTO { get; set; }
        public string GE089_SEQ_PRODUTO_VRS { get; set; }
        public string GE089_DTA_INI_VIGENCIA { get; set; }
        public string GE089_DTA_FIM_VIGENCIA { get; set; }
        public string GE089_IND_FLUXO_PARAMTRIZADO { get; set; }
        public string GE089_COD_PERIOD_VIGENCIA { get; set; }
        public string GE089_QTD_PERIOD_VIGENCIA { get; set; }
        public string GE089_COD_MOEDA { get; set; }
        public string GE089_IND_RENOVA { get; set; }
        public string GE089_IND_RENOVA_AUTOMATICA { get; set; }
        public string GE089_QTD_RENOVA_AUTOMATICA { get; set; }
        public string GE089_IND_DPS { get; set; }
        public string GE089_IND_REENQUADRA_PREMIO { get; set; }
        public string GE089_IND_REAJUSTE_PREMIO { get; set; }
        public string GE089_COD_INDICE_REAJUSTE { get; set; }
        public string GE089_COD_PERIOD_REAJUSTE { get; set; }
        public string GE089_COD_INDICE_DEVOLUCAO { get; set; }
        public string GE089_PCT_JUROS_DEVOLUCAO { get; set; }
        public string GE089_PCT_MULTA_DEVOLUCAO { get; set; }
        public string GE089_IND_FLUXO_COMISSAO { get; set; }
        public string GE089_IND_ACOPLADO { get; set; }
        public string GE089_IND_FLUXO_SINISTRO { get; set; }
        public string GE089_IND_CONJUGE { get; set; }
        public string GE089_COD_USUARIO { get; set; }
        public string GE089_NOM_PROGRAMA { get; set; }
        public string GE089_DTH_CADASTRAMENTO { get; set; }

        public static P0201_05_INICIO_DB_SELECT_1_Query1 Execute(P0201_05_INICIO_DB_SELECT_1_Query1 p0201_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0201_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0201_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0201_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE089_COD_PRODUTO = result[i++].Value?.ToString();
            dta.GE089_SEQ_PRODUTO_VRS = result[i++].Value?.ToString();
            dta.GE089_DTA_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.GE089_DTA_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.GE089_IND_FLUXO_PARAMTRIZADO = result[i++].Value?.ToString();
            dta.GE089_COD_PERIOD_VIGENCIA = result[i++].Value?.ToString();
            dta.GE089_QTD_PERIOD_VIGENCIA = result[i++].Value?.ToString();
            dta.GE089_COD_MOEDA = result[i++].Value?.ToString();
            dta.GE089_IND_RENOVA = result[i++].Value?.ToString();
            dta.GE089_IND_RENOVA_AUTOMATICA = result[i++].Value?.ToString();
            dta.GE089_QTD_RENOVA_AUTOMATICA = result[i++].Value?.ToString();
            dta.GE089_IND_DPS = result[i++].Value?.ToString();
            dta.GE089_IND_REENQUADRA_PREMIO = result[i++].Value?.ToString();
            dta.GE089_IND_REAJUSTE_PREMIO = result[i++].Value?.ToString();
            dta.GE089_COD_INDICE_REAJUSTE = result[i++].Value?.ToString();
            dta.GE089_COD_PERIOD_REAJUSTE = result[i++].Value?.ToString();
            dta.GE089_COD_INDICE_DEVOLUCAO = result[i++].Value?.ToString();
            dta.GE089_PCT_JUROS_DEVOLUCAO = result[i++].Value?.ToString();
            dta.GE089_PCT_MULTA_DEVOLUCAO = result[i++].Value?.ToString();
            dta.GE089_IND_FLUXO_COMISSAO = result[i++].Value?.ToString();
            dta.GE089_IND_ACOPLADO = result[i++].Value?.ToString();
            dta.GE089_IND_FLUXO_SINISTRO = result[i++].Value?.ToString();
            dta.GE089_IND_CONJUGE = result[i++].Value?.ToString();
            dta.GE089_COD_USUARIO = result[i++].Value?.ToString();
            dta.GE089_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.GE089_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}