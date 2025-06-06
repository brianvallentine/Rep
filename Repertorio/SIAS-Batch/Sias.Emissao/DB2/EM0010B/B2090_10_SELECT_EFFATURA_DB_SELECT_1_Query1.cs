using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1 : QueryBasis<B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VLR_EMISSAO - VALUE(VLR_IOF_EMISSAO,0)),0)
            ,VALUE(SUM(VLR_CREDITO - VALUE(VLR_IOF_CREDITO,0)),0)
            ,VALUE(SUM(VLR_IOF_EMISSAO),0)
            ,VALUE(SUM(VLR_IOF_CREDITO),0)
            INTO :WS-EF-VLR-EMISSAO ,
            :WS-EF-VLR-CREDITO ,
            :WS-EF-IOF-EMISSAO ,
            :WS-EF-IOF-CREDITO
            FROM SEGUROS.EF_ENDOSSO E,
            SEGUROS.EF_FATURAS_ENDOSSO FE,
            SEGUROS.EF_FATURA F
            WHERE E.NUM_ENDOSSO = :ENDO-NRENDOS
            AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO
            AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR
            AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO
            AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO
            AND F.COD_PRODUTO = :ENDO-CODPRODU
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VLR_EMISSAO - VALUE(VLR_IOF_EMISSAO
							,0))
							,0)
											,VALUE(SUM(VLR_CREDITO - VALUE(VLR_IOF_CREDITO
							,0))
							,0)
											,VALUE(SUM(VLR_IOF_EMISSAO)
							,0)
											,VALUE(SUM(VLR_IOF_CREDITO)
							,0)
											FROM SEGUROS.EF_ENDOSSO E
							,
											SEGUROS.EF_FATURAS_ENDOSSO FE
							,
											SEGUROS.EF_FATURA F
											WHERE E.NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO
											AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR
											AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO
											AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO
											AND F.COD_PRODUTO = '{this.ENDO_CODPRODU}'
											WITH UR";

            return query;
        }
        public string WS_EF_VLR_EMISSAO { get; set; }
        public string WS_EF_VLR_CREDITO { get; set; }
        public string WS_EF_IOF_EMISSAO { get; set; }
        public string WS_EF_IOF_CREDITO { get; set; }
        public string ENDO_CODPRODU { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1 Execute(B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1 b2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1)
        {
            var ths = b2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_EF_VLR_EMISSAO = result[i++].Value?.ToString();
            dta.WS_EF_VLR_CREDITO = result[i++].Value?.ToString();
            dta.WS_EF_IOF_EMISSAO = result[i++].Value?.ToString();
            dta.WS_EF_IOF_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}