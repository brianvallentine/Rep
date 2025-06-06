using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_RCAP
            ,A.VAL_RCAP
            ,A.DATA_CADASTRAMENTO
            ,A.SIT_REGISTRO
            ,A.COD_OPERACAO
            ,B.BCO_AVISO
            ,B.AGE_AVISO
            ,B.NUM_AVISO_CREDITO
            INTO :RCAPS-NUM-RCAP
            ,:RCAPS-VAL-RCAP
            ,:RCAPS-DATA-CADASTRAMENTO
            ,:RCAPS-SIT-REGISTRO
            ,:RCAPS-COD-OPERACAO
            ,:RCAPCOMP-BCO-AVISO
            ,:RCAPCOMP-AGE-AVISO
            ,:RCAPCOMP-NUM-AVISO-CREDITO
            FROM SEGUROS.RCAPS A
            ,SEGUROS.RCAP_COMPLEMENTAR B
            WHERE A.NUM_TITULO = :HISCONPA-NUM-TITULO
            AND B.COD_FONTE = A.COD_FONTE
            AND B.NUM_RCAP = A.NUM_RCAP
            AND B.SIT_REGISTRO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_RCAP
											,A.VAL_RCAP
											,A.DATA_CADASTRAMENTO
											,A.SIT_REGISTRO
											,A.COD_OPERACAO
											,B.BCO_AVISO
											,B.AGE_AVISO
											,B.NUM_AVISO_CREDITO
											FROM SEGUROS.RCAPS A
											,SEGUROS.RCAP_COMPLEMENTAR B
											WHERE A.NUM_TITULO = '{this.HISCONPA_NUM_TITULO}'
											AND B.COD_FONTE = A.COD_FONTE
											AND B.NUM_RCAP = A.NUM_RCAP
											AND B.SIT_REGISTRO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }

        public static R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0410_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}