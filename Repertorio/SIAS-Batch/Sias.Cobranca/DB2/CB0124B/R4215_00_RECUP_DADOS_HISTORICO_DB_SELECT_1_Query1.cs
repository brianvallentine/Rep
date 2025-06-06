using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1 : QueryBasis<R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DATA_VENCIMENTO
            , A.OCORR_HISTORICO
            , A.PRM_TARIFARIO
            , A.VAL_DESCONTO
            , A.PRM_LIQUIDO
            , A.ADICIONAL_FRACIO
            , A.VAL_CUSTO_EMISSAO
            , A.VAL_IOCC
            , A.PRM_TOTAL
            , A.NUM_PARCELA
            INTO :PARCEHIS-DATA-VENCIMENTO
            , :PARCEHIS-OCORR-HISTORICO
            , :PARCEHIS-PRM-TARIFARIO
            , :PARCEHIS-VAL-DESCONTO
            , :PARCEHIS-PRM-LIQUIDO
            , :PARCEHIS-ADICIONAL-FRACIO
            , :PARCEHIS-VAL-CUSTO-EMISSAO
            , :PARCEHIS-VAL-IOCC
            , :PARCEHIS-PRM-TOTAL
            , :PARCEHIS-NUM-PARCELA
            FROM SEGUROS.PARCELA_HISTORICO A
            ,SEGUROS.PARCELAS B
            WHERE A.NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND A.NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND A.NUM_PARCELA = :PARCEHIS-NUM-PARCELA
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.DATA_VENCIMENTO
											, A.OCORR_HISTORICO
											, A.PRM_TARIFARIO
											, A.VAL_DESCONTO
											, A.PRM_LIQUIDO
											, A.ADICIONAL_FRACIO
											, A.VAL_CUSTO_EMISSAO
											, A.VAL_IOCC
											, A.PRM_TOTAL
											, A.NUM_PARCELA
											FROM SEGUROS.PARCELA_HISTORICO A
											,SEGUROS.PARCELAS B
											WHERE A.NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND A.NUM_PARCELA = '{this.PARCEHIS_NUM_PARCELA}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											AND A.OCORR_HISTORICO = B.OCORR_HISTORICO
											WITH UR";

            return query;
        }
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_PRM_TARIFARIO { get; set; }
        public string PARCEHIS_VAL_DESCONTO { get; set; }
        public string PARCEHIS_PRM_LIQUIDO { get; set; }
        public string PARCEHIS_ADICIONAL_FRACIO { get; set; }
        public string PARCEHIS_VAL_CUSTO_EMISSAO { get; set; }
        public string PARCEHIS_VAL_IOCC { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1 Execute(R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1 r4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1)
        {
            var ths = r4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TARIFARIO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_DESCONTO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.PARCEHIS_ADICIONAL_FRACIO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_CUSTO_EMISSAO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_IOCC = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}