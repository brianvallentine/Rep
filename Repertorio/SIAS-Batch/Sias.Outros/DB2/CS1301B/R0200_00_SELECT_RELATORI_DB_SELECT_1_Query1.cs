using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CS1301B
{
    public class R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_SOLICITACAO ,
            DATA_REFERENCIA ,
            PERI_INICIAL ,
            PERI_FINAL ,
            (PERI_INICIAL + 7 DAYS),
            (PERI_FINAL + 7 DAYS)
            INTO :RELATORI-DATA-SOLICITACAO ,
            :RELATORI-DATA-REFERENCIA ,
            :RELATORI-PERI-INICIAL ,
            :RELATORI-PERI-FINAL ,
            :RELATORI-PROX-INICIAL ,
            :RELATORI-PROX-FINAL
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'CS1301B1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_SOLICITACAO 
							,
											DATA_REFERENCIA 
							,
											PERI_INICIAL 
							,
											PERI_FINAL 
							,
											(PERI_INICIAL + 7 DAYS)
							,
											(PERI_FINAL + 7 DAYS)
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO = 'CS1301B1'";

            return query;
        }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string RELATORI_PROX_INICIAL { get; set; }
        public string RELATORI_PROX_FINAL { get; set; }

        public static R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1 r0200_00_SELECT_RELATORI_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_RELATORI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            dta.RELATORI_PROX_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PROX_FINAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}