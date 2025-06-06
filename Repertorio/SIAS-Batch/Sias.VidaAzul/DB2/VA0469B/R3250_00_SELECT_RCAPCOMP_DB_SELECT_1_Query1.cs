using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            ,NUM_RCAP
            ,NUM_RCAP_COMPLEMEN
            ,COD_OPERACAO
            ,BCO_AVISO
            ,AGE_AVISO
            ,NUM_AVISO_CREDITO
            ,VAL_RCAP
            ,DATA_RCAP
            ,DATA_CADASTRAMENTO
            INTO :RCAPCOMP-COD-FONTE
            ,:RCAPCOMP-NUM-RCAP
            ,:RCAPCOMP-NUM-RCAP-COMPLEMEN
            ,:RCAPCOMP-COD-OPERACAO
            ,:RCAPCOMP-BCO-AVISO
            ,:RCAPCOMP-AGE-AVISO
            ,:RCAPCOMP-NUM-AVISO-CREDITO
            ,:RCAPCOMP-VAL-RCAP
            ,:RCAPCOMP-DATA-RCAP
            ,:RCAPCOMP-DATA-CADASTRAMENTO
            FROM SEGUROS.RCAP_COMPLEMENTAR
            WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP
            AND COD_FONTE = :RCAPCOMP-COD-FONTE
            AND SIT_REGISTRO = '0'
            AND NUM_RCAP_COMPLEMEN = 0
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											,NUM_RCAP
											,NUM_RCAP_COMPLEMEN
											,COD_OPERACAO
											,BCO_AVISO
											,AGE_AVISO
											,NUM_AVISO_CREDITO
											,VAL_RCAP
											,DATA_RCAP
											,DATA_CADASTRAMENTO
											FROM SEGUROS.RCAP_COMPLEMENTAR
											WHERE NUM_RCAP = '{this.RCAPCOMP_NUM_RCAP}'
											AND COD_FONTE = '{this.RCAPCOMP_COD_FONTE}'
											AND SIT_REGISTRO = '0'
											AND NUM_RCAP_COMPLEMEN = 0
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPCOMP_NUM_RCAP_COMPLEMEN { get; set; }
        public string RCAPCOMP_COD_OPERACAO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPCOMP_DATA_CADASTRAMENTO { get; set; }

        public static R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 Execute(R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 r3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_RCAP_COMPLEMEN = result[i++].Value?.ToString();
            dta.RCAPCOMP_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPCOMP_BCO_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_AGE_AVISO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.RCAPCOMP_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}