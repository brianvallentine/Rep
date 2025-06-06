using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_SOLICITACAO
            , COD_RELATORIO
            , NUM_CERTIFICADO
            , NUM_PARCELA
            , COD_PLANO
            , TIMESTAMP
            INTO :RELATORI-DATA-SOLICITACAO
            ,:RELATORI-COD-RELATORIO
            ,:RELATORI-NUM-CERTIFICADO
            ,:RELATORI-NUM-PARCELA
            ,:RELATORI-COD-PLANO
            ,:RELATORI-TIMESTAMP
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO IN ( 'VGICA' , 'VGIDA' , 'VGIEA' )
            AND SIT_REGISTRO = '0'
            AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA > 0
            AND COD_PLANO > 0
            ORDER BY COD_RELATORIO ,
            NUM_CERTIFICADO ,
            NUM_PARCELA ,
            TIMESTAMP DESC
            FETCH FIRST 1 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_SOLICITACAO
											, COD_RELATORIO
											, NUM_CERTIFICADO
											, NUM_PARCELA
											, COD_PLANO
											, TIMESTAMP
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO IN ( 'VGICA' 
							, 'VGIDA' 
							, 'VGIEA' )
											AND SIT_REGISTRO = '0'
											AND NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_PARCELA > 0
											AND COD_PLANO > 0
											ORDER BY COD_RELATORIO 
							,
											NUM_CERTIFICADO 
							,
											NUM_PARCELA 
							,
											TIMESTAMP DESC
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_COD_PLANO { get; set; }
        public string RELATORI_TIMESTAMP { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1 Execute(R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1 r1015_SELECT_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r1015_SELECT_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.RELATORI_COD_PLANO = result[i++].Value?.ToString();
            dta.RELATORI_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}