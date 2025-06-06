using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_BILHETE
            ,RAMO
            ,SITUACAO
            ,DATA_QUITACAO + :WIND MONTH + 1 DAY
            ,DATA_QUITACAO + :WIND2 MONTH
            ,DATA_QUITACAO + :WIND3 MONTH
            INTO :BILHETE-NUM-BILHETE
            ,:BILHETE-RAMO
            ,:BILHETE-SITUACAO
            ,:WSGER00-DATA-INIVIGENCIA
            ,:WSGER00-DATA-TERVIGENCIA
            ,:WSGER00-DATA-CORRETOR
            FROM SEGUROS.BILHETE
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_BILHETE
											,RAMO
											,SITUACAO
											,DATA_QUITACAO + {this.WIND} MONTH + 1 DAY
											,DATA_QUITACAO + {this.WIND2} MONTH
											,DATA_QUITACAO + {this.WIND3} MONTH
											FROM SEGUROS.BILHETE
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string WSGER00_DATA_INIVIGENCIA { get; set; }
        public string WSGER00_DATA_TERVIGENCIA { get; set; }
        public string WSGER00_DATA_CORRETOR { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string WIND2 { get; set; }
        public string WIND3 { get; set; }
        public string WIND { get; set; }

        public static R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1 r0240_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0240_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.WSGER00_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER00_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER00_DATA_CORRETOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}