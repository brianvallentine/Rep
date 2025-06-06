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
    public class R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_FONTE
            , B.NUM_APOLICE
            , B.COD_SUBGRUPO
            , C.PREMIO_VG
            , C.PREMIO_AP
            , DATE(C.TIMESTAMP)
            , D.NUM_TITULO
            , D.OCORR_HISTORICO
            INTO :PROPOVA-COD-FONTE
            , :PROPOVA-NUM-APOLICE
            , :PROPOVA-COD-SUBGRUPO
            , :PARCEVID-PREMIO-VG
            , :PARCEVID-PREMIO-AP
            , :WS-DATA-GERACAO-PARCELA
            , :COBHISVI-NUM-TITULO
            , :COBHISVI-OCORR-HISTORICO
            FROM SEGUROS.HIST_LANC_CTA A
            , SEGUROS.PROPOSTAS_VA B
            , SEGUROS.PARCELAS_VIDAZUL C
            , SEGUROS.COBER_HIST_VIDAZUL D
            WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA
            AND A.OCORR_HISTORICOCTA = :HISLANCT-OCORR-HISTORICOCTA
            AND A.SIT_REGISTRO IN ( '3' , 'A' , ' ' , '2' )
            AND A.TIPLANC = '1'
            AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND B.SIT_REGISTRO IN ( '3' , '6' , '4' )
            AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO
            AND A.NUM_PARCELA = C.NUM_PARCELA
            AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO
            AND A.NUM_PARCELA = D.NUM_PARCELA
            AND A.CODCONV = 9020
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.COD_FONTE
											, B.NUM_APOLICE
											, B.COD_SUBGRUPO
											, C.PREMIO_VG
											, C.PREMIO_AP
											, DATE(C.TIMESTAMP)
											, D.NUM_TITULO
											, D.OCORR_HISTORICO
											FROM SEGUROS.HIST_LANC_CTA A
											, SEGUROS.PROPOSTAS_VA B
											, SEGUROS.PARCELAS_VIDAZUL C
											, SEGUROS.COBER_HIST_VIDAZUL D
											WHERE A.NUM_CERTIFICADO = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.HISLANCT_NUM_PARCELA}'
											AND A.OCORR_HISTORICOCTA = '{this.HISLANCT_OCORR_HISTORICOCTA}'
											AND A.SIT_REGISTRO IN ( '3' 
							, 'A' 
							, ' ' 
							, '2' )
											AND A.TIPLANC = '1'
											AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND B.SIT_REGISTRO IN ( '3' 
							, '6' 
							, '4' )
											AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO
											AND A.NUM_PARCELA = C.NUM_PARCELA
											AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO
											AND A.NUM_PARCELA = D.NUM_PARCELA
											AND A.CODCONV = 9020
											WITH UR";

            return query;
        }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_PREMIO_AP { get; set; }
        public string WS_DATA_GERACAO_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }

        public static R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 Execute(R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 r3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_VG = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_AP = result[i++].Value?.ToString();
            dta.WS_DATA_GERACAO_PARCELA = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            dta.COBHISVI_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}