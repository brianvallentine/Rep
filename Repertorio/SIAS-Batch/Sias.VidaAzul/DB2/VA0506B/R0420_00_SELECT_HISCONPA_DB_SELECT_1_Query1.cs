using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO
            , A.NUM_PARCELA
            , A.NUM_TITULO
            , A.OCORR_HISTORICO
            , A.NUM_APOLICE
            , A.COD_SUBGRUPO
            , A.NUM_ENDOSSO
            , B.RAMO_EMISSOR
            , B.DATA_INIVIGENCIA
            , C.COD_MODALIDADE
            INTO :HISCONPA-NUM-CERTIFICADO
            ,:HISCONPA-NUM-PARCELA
            ,:HISCONPA-NUM-TITULO
            ,:HISCONPA-OCORR-HISTORICO
            ,:HISCONPA-NUM-APOLICE
            ,:HISCONPA-COD-SUBGRUPO
            ,:HISCONPA-NUM-ENDOSSO
            ,:ENDOSSOS-RAMO-EMISSOR
            ,:ENDOSSOS-DATA-INIVIGENCIA
            ,:APOLICES-COD-MODALIDADE
            FROM SEGUROS.HIST_CONT_PARCELVA A
            , SEGUROS.ENDOSSOS B
            , SEGUROS.APOLICES C
            WHERE A.NUM_APOLICE = :FUNCOMVA-NUM-APOLICE
            AND A.NUM_ENDOSSO = :FUNCOMVA-NUM-ENDOSSO
            AND A.NUM_TITULO = :FUNCOMVA-NUM-TITULO
            AND A.NUM_PARCELA IN (0,1)
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.TIPO_ENDOSSO IN ( '0' , '1' )
            AND C.NUM_APOLICE = B.NUM_APOLICE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
											, A.NUM_PARCELA
											, A.NUM_TITULO
											, A.OCORR_HISTORICO
											, A.NUM_APOLICE
											, A.COD_SUBGRUPO
											, A.NUM_ENDOSSO
											, B.RAMO_EMISSOR
											, B.DATA_INIVIGENCIA
											, C.COD_MODALIDADE
											FROM SEGUROS.HIST_CONT_PARCELVA A
											, SEGUROS.ENDOSSOS B
											, SEGUROS.APOLICES C
											WHERE A.NUM_APOLICE = '{this.FUNCOMVA_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.FUNCOMVA_NUM_ENDOSSO}'
											AND A.NUM_TITULO = '{this.FUNCOMVA_NUM_TITULO}'
											AND A.NUM_PARCELA IN (0
							,1)
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.TIPO_ENDOSSO IN ( '0' 
							, '1' )
											AND C.NUM_APOLICE = B.NUM_APOLICE
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string FUNCOMVA_NUM_APOLICE { get; set; }
        public string FUNCOMVA_NUM_ENDOSSO { get; set; }
        public string FUNCOMVA_NUM_TITULO { get; set; }

        public static R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1 r0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCONPA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_TITULO = result[i++].Value?.ToString();
            dta.HISCONPA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.HISCONPA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}