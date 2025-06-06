using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NUM_RCAP
            ,C.VAL_RCAP
            ,C.DATA_CADASTRAMENTO
            ,C.SIT_REGISTRO
            ,C.COD_OPERACAO
            ,C.NUM_TITULO
            ,B.BCO_AVISO
            ,B.AGE_AVISO
            ,B.NUM_AVISO_CREDITO
            INTO :RCAPS-NUM-RCAP
            ,:RCAPS-VAL-RCAP
            ,:RCAPS-DATA-CADASTRAMENTO
            ,:RCAPS-SIT-REGISTRO
            ,:RCAPS-COD-OPERACAO
            ,:RCAPS-NUM-TITULO
            ,:RCAPCOMP-BCO-AVISO
            ,:RCAPCOMP-AGE-AVISO
            ,:RCAPCOMP-NUM-AVISO-CREDITO
            FROM SEGUROS.COBER_HIST_VIDAZUL A
            ,SEGUROS.RCAP_COMPLEMENTAR B
            ,SEGUROS.RCAPS C
            WHERE A.NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :COBHISVI-NUM-PARCELA
            AND B.BCO_AVISO = A.BCO_AVISO
            AND B.AGE_AVISO = A.AGE_AVISO
            AND B.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO
            AND B.VAL_RCAP = A.PRM_TOTAL
            AND B.SIT_REGISTRO = '0'
            AND C.COD_FONTE = B.COD_FONTE
            AND C.NUM_RCAP = B.NUM_RCAP
            AND C.NUM_APOLICE = :RCAPS-NUM-APOLICE
            AND C.NUM_ENDOSSO = :RCAPS-NUM-ENDOSSO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.NUM_RCAP
											,C.VAL_RCAP
											,C.DATA_CADASTRAMENTO
											,C.SIT_REGISTRO
											,C.COD_OPERACAO
											,C.NUM_TITULO
											,B.BCO_AVISO
											,B.AGE_AVISO
											,B.NUM_AVISO_CREDITO
											FROM SEGUROS.COBER_HIST_VIDAZUL A
											,SEGUROS.RCAP_COMPLEMENTAR B
											,SEGUROS.RCAPS C
											WHERE A.NUM_CERTIFICADO = '{this.COBHISVI_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.COBHISVI_NUM_PARCELA}'
											AND B.BCO_AVISO = A.BCO_AVISO
											AND B.AGE_AVISO = A.AGE_AVISO
											AND B.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO
											AND B.VAL_RCAP = A.PRM_TOTAL
											AND B.SIT_REGISTRO = '0'
											AND C.COD_FONTE = B.COD_FONTE
											AND C.NUM_RCAP = B.NUM_RCAP
											AND C.NUM_APOLICE = '{this.RCAPS_NUM_APOLICE}'
											AND C.NUM_ENDOSSO = '{this.RCAPS_NUM_ENDOSSO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }
        public string RCAPS_NUM_APOLICE { get; set; }
        public string RCAPS_NUM_ENDOSSO { get; set; }

        public static R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0190_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0190_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}