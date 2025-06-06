using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO
            , A.NUM_PARCELA
            , A.NUM_ENDOSSO
            , A.NUM_APOLICE
            , A.SIT_REGISTRO
            , C.DAC_PARCELA
            , C.PRM_TARIFARIO_IX
            , C.VAL_DESCONTO_IX
            , C.PRM_LIQUIDO_IX
            , C.ADICIONAL_FRAC_IX
            , C.VAL_CUSTO_EMIS_IX
            , C.VAL_IOCC_IX
            , C.PRM_TOTAL_IX
            , C.QTD_DOCUMENTOS
            , B.COD_PRODUTO
            , D.TIPO_CORRECAO
            , D.COD_MOEDA_PRM
            , D.COD_USUARIO
            , E.NUM_TITULO
            INTO :HISCONPA-NUM-CERTIFICADO
            , :HISCONPA-NUM-PARCELA
            , :HISCONPA-NUM-ENDOSSO
            , :HISCONPA-NUM-APOLICE
            , :HISCONPA-SIT-REGISTRO
            , :PARCELAS-DAC-PARCELA
            , :PARCELAS-PRM-TARIFARIO-IX
            , :PARCELAS-VAL-DESCONTO-IX
            , :PARCELAS-PRM-LIQUIDO-IX
            , :PARCELAS-ADICIONAL-FRAC-IX
            , :PARCELAS-VAL-CUSTO-EMIS-IX
            , :PARCELAS-VAL-IOCC-IX
            , :PARCELAS-PRM-TOTAL-IX
            , :PARCELAS-QTD-DOCUMENTOS
            , :PROPOVA-COD-PRODUTO
            , :ENDOSSOS-TIPO-CORRECAO
            , :ENDOSSOS-COD-MOEDA-PRM
            , :ENDOSSOS-COD-USUARIO
            , :COBHISVI-NUM-TITULO
            FROM SEGUROS.HIST_CONT_PARCELVA A
            , SEGUROS.PROPOSTAS_VA B
            , SEGUROS.PARCELAS C
            , SEGUROS.ENDOSSOS D
            , SEGUROS.COBER_HIST_VIDAZUL E
            WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND A.NUM_TITULO > 0
            AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA
            AND A.COD_OPERACAO BETWEEN 200 AND 299
            AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.NUM_APOLICE = C.NUM_APOLICE
            AND A.NUM_ENDOSSO = C.NUM_ENDOSSO
            AND A.NUM_APOLICE = D.NUM_APOLICE
            AND A.NUM_ENDOSSO = D.NUM_ENDOSSO
            AND A.NUM_CERTIFICADO = E.NUM_CERTIFICADO
            AND A.NUM_PARCELA = E.NUM_PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
											, A.NUM_PARCELA
											, A.NUM_ENDOSSO
											, A.NUM_APOLICE
											, A.SIT_REGISTRO
											, C.DAC_PARCELA
											, C.PRM_TARIFARIO_IX
											, C.VAL_DESCONTO_IX
											, C.PRM_LIQUIDO_IX
											, C.ADICIONAL_FRAC_IX
											, C.VAL_CUSTO_EMIS_IX
											, C.VAL_IOCC_IX
											, C.PRM_TOTAL_IX
											, C.QTD_DOCUMENTOS
											, B.COD_PRODUTO
											, D.TIPO_CORRECAO
											, D.COD_MOEDA_PRM
											, D.COD_USUARIO
											, E.NUM_TITULO
											FROM SEGUROS.HIST_CONT_PARCELVA A
											, SEGUROS.PROPOSTAS_VA B
											, SEGUROS.PARCELAS C
											, SEGUROS.ENDOSSOS D
											, SEGUROS.COBER_HIST_VIDAZUL E
											WHERE A.NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND A.NUM_TITULO > 0
											AND A.NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											AND A.COD_OPERACAO BETWEEN 200 AND 299
											AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.NUM_APOLICE = C.NUM_APOLICE
											AND A.NUM_ENDOSSO = C.NUM_ENDOSSO
											AND A.NUM_APOLICE = D.NUM_APOLICE
											AND A.NUM_ENDOSSO = D.NUM_ENDOSSO
											AND A.NUM_CERTIFICADO = E.NUM_CERTIFICADO
											AND A.NUM_PARCELA = E.NUM_PARCELA
											WITH UR";

            return query;
        }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string PARCELAS_DAC_PARCELA { get; set; }
        public string PARCELAS_PRM_TARIFARIO_IX { get; set; }
        public string PARCELAS_VAL_DESCONTO_IX { get; set; }
        public string PARCELAS_PRM_LIQUIDO_IX { get; set; }
        public string PARCELAS_ADICIONAL_FRAC_IX { get; set; }
        public string PARCELAS_VAL_CUSTO_EMIS_IX { get; set; }
        public string PARCELAS_VAL_IOCC_IX { get; set; }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string PARCELAS_QTD_DOCUMENTOS { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string ENDOSSOS_TIPO_CORRECAO { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }
        public string ENDOSSOS_COD_USUARIO { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }

        public static R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0310_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCONPA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.HISCONPA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PARCELAS_DAC_PARCELA = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_DESCONTO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_LIQUIDO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_ADICIONAL_FRAC_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_CUSTO_EMIS_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_IOCC_IX = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TOTAL_IX = result[i++].Value?.ToString();
            dta.PARCELAS_QTD_DOCUMENTOS = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_USUARIO = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}