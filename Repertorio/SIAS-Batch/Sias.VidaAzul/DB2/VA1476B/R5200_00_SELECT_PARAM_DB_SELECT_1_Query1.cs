using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R5200_00_SELECT_PARAM_DB_SELECT_1_Query1 : QueryBasis<R5200_00_SELECT_PARAM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.COD_CLIENTE ,
            T1.PARAM_SMINT01 ,
            T1.PARAM_INTG01 ,
            T1.PARAM_INTG02 ,
            T1.PARAM_INTG03 ,
            T1.PARAM_DEC01 ,
            T1.DATA_SOLICITACAO
            INTO :LTSOLPAR-COD-CLIENTE ,
            :LTSOLPAR-PARAM-SMINT01 ,
            :LTSOLPAR-PARAM-INTG01 ,
            :LTSOLPAR-PARAM-INTG02 ,
            :LTSOLPAR-PARAM-INTG03 ,
            :LTSOLPAR-PARAM-DEC01 ,
            :LTSOLPAR-DATA-SOLICITACAO
            FROM SEGUROS.LT_SOLICITA_PARAM T1
            WHERE T1.COD_PROGRAMA = 'VA1476B'
            AND T1.SIT_SOLICITACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.COD_CLIENTE 
							,
											T1.PARAM_SMINT01 
							,
											T1.PARAM_INTG01 
							,
											T1.PARAM_INTG02 
							,
											T1.PARAM_INTG03 
							,
											T1.PARAM_DEC01 
							,
											T1.DATA_SOLICITACAO
											FROM SEGUROS.LT_SOLICITA_PARAM T1
											WHERE T1.COD_PROGRAMA = 'VA1476B'
											AND T1.SIT_SOLICITACAO = '0'
											WITH UR";

            return query;
        }
        public string LTSOLPAR_COD_CLIENTE { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_PARAM_INTG01 { get; set; }
        public string LTSOLPAR_PARAM_INTG02 { get; set; }
        public string LTSOLPAR_PARAM_INTG03 { get; set; }
        public string LTSOLPAR_PARAM_DEC01 { get; set; }
        public string LTSOLPAR_DATA_SOLICITACAO { get; set; }

        public static R5200_00_SELECT_PARAM_DB_SELECT_1_Query1 Execute(R5200_00_SELECT_PARAM_DB_SELECT_1_Query1 r5200_00_SELECT_PARAM_DB_SELECT_1_Query1)
        {
            var ths = r5200_00_SELECT_PARAM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5200_00_SELECT_PARAM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5200_00_SELECT_PARAM_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTSOLPAR_COD_CLIENTE = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_SMINT01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_INTG01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_INTG02 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_INTG03 = result[i++].Value?.ToString();
            dta.LTSOLPAR_PARAM_DEC01 = result[i++].Value?.ToString();
            dta.LTSOLPAR_DATA_SOLICITACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}