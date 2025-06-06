using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R10_PROCESSA_DATA_DB_SELECT_1_Query1 : QueryBasis<R10_PROCESSA_DATA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            MONTH(DATA_MOV_ABERTO) AS MES ,
            YEAR(DATA_MOV_ABERTO) AS ANO ,
            DATULT_PROCESSAMEN
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :HOST-MES-MOV-ABERTO,
            :HOST-ANO-MOV-ABERTO,
            :SISTEMAS-DATULT-PROCESSAMEN
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											MONTH(DATA_MOV_ABERTO) AS MES 
							,
											YEAR(DATA_MOV_ABERTO) AS ANO 
							,
											DATULT_PROCESSAMEN
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string HOST_MES_MOV_ABERTO { get; set; }
        public string HOST_ANO_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATULT_PROCESSAMEN { get; set; }

        public static R10_PROCESSA_DATA_DB_SELECT_1_Query1 Execute(R10_PROCESSA_DATA_DB_SELECT_1_Query1 r10_PROCESSA_DATA_DB_SELECT_1_Query1)
        {
            var ths = r10_PROCESSA_DATA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R10_PROCESSA_DATA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R10_PROCESSA_DATA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.HOST_MES_MOV_ABERTO = result[i++].Value?.ToString();
            dta.HOST_ANO_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DATULT_PROCESSAMEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}