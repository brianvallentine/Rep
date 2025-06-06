using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0071S
{
    public class P0202_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0202_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPC_COBERTURA
            ,NUM_IDADE_INI
            ,NUM_IDADE_FIM
            ,COD_OPC_PLANO
            ,VLR_INI_PREMIO
            ,VLR_FIM_PREMIO
            ,PCT_IOF
            ,PCT_REENQUADRAMENTO
            ,IND_PERMIT_VENDA
            INTO :GE090-COD-OPC-COBERTURA
            ,:GE090-NUM-IDADE-INI
            ,:GE090-NUM-IDADE-FIM
            ,:GE090-COD-OPC-PLANO
            ,:GE090-VLR-INI-PREMIO
            ,:GE090-VLR-FIM-PREMIO
            ,:GE090-PCT-IOF
            ,:GE090-PCT-REENQUADRAMENTO
            ,:GE090-IND-PERMIT-VENDA
            FROM SEGUROS.GE_PRODUTO_PREMIO
            WHERE COD_PRODUTO = :GE090-COD-PRODUTO
            AND SEQ_PRODUTO_VRS = :GE090-SEQ-PRODUTO-VRS
            AND COD_OPC_PLANO = :GE090-COD-OPC-PLANO
            AND IND_CONJUGE = :GE090-IND-CONJUGE
            AND :GE090-NUM-IDADE-INI BETWEEN
            NUM_IDADE_INI AND NUM_IDADE_FIM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPC_COBERTURA
											,NUM_IDADE_INI
											,NUM_IDADE_FIM
											,COD_OPC_PLANO
											,VLR_INI_PREMIO
											,VLR_FIM_PREMIO
											,PCT_IOF
											,PCT_REENQUADRAMENTO
											,IND_PERMIT_VENDA
											FROM SEGUROS.GE_PRODUTO_PREMIO
											WHERE COD_PRODUTO = '{this.GE090_COD_PRODUTO}'
											AND SEQ_PRODUTO_VRS = '{this.GE090_SEQ_PRODUTO_VRS}'
											AND COD_OPC_PLANO = '{this.GE090_COD_OPC_PLANO}'
											AND IND_CONJUGE = '{this.GE090_IND_CONJUGE}'
											AND '{this.GE090_NUM_IDADE_INI}' BETWEEN
											NUM_IDADE_INI AND NUM_IDADE_FIM
											WITH UR";

            return query;
        }
        public string GE090_COD_OPC_COBERTURA { get; set; }
        public string GE090_NUM_IDADE_INI { get; set; }
        public string GE090_NUM_IDADE_FIM { get; set; }
        public string GE090_COD_OPC_PLANO { get; set; }
        public string GE090_VLR_INI_PREMIO { get; set; }
        public string GE090_VLR_FIM_PREMIO { get; set; }
        public string GE090_PCT_IOF { get; set; }
        public string GE090_PCT_REENQUADRAMENTO { get; set; }
        public string GE090_IND_PERMIT_VENDA { get; set; }
        public string GE090_SEQ_PRODUTO_VRS { get; set; }
        public string GE090_COD_PRODUTO { get; set; }
        public string GE090_IND_CONJUGE { get; set; }

        public static P0202_05_INICIO_DB_SELECT_1_Query1 Execute(P0202_05_INICIO_DB_SELECT_1_Query1 p0202_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0202_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0202_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0202_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE090_COD_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.GE090_NUM_IDADE_INI = result[i++].Value?.ToString();
            dta.GE090_NUM_IDADE_FIM = result[i++].Value?.ToString();
            dta.GE090_COD_OPC_PLANO = result[i++].Value?.ToString();
            dta.GE090_VLR_INI_PREMIO = result[i++].Value?.ToString();
            dta.GE090_VLR_FIM_PREMIO = result[i++].Value?.ToString();
            dta.GE090_PCT_IOF = result[i++].Value?.ToString();
            dta.GE090_PCT_REENQUADRAMENTO = result[i++].Value?.ToString();
            dta.GE090_IND_PERMIT_VENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}