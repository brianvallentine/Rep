using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0220B
{
    public class R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1 : QueryBasis<R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUREG ,
            COD_AGENCIA ,
            COD_OPERACAO ,
            NUM_CONTRATO ,
            CONTRATO_DIGITO
            INTO :SINCREIN-COD-SUREG,
            :SINCREIN-COD-AGENCIA,
            :SINCREIN-COD-OPERACAO,
            :SINCREIN-NUM-CONTRATO,
            :SINCREIN-CONTRATO-DIGITO
            FROM SEGUROS.SINISTRO_CRED_INT
            WHERE NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUREG 
							,
											COD_AGENCIA 
							,
											COD_OPERACAO 
							,
											NUM_CONTRATO 
							,
											CONTRATO_DIGITO
											FROM SEGUROS.SINISTRO_CRED_INT
											WHERE NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINCREIN_COD_SUREG { get; set; }
        public string SINCREIN_COD_AGENCIA { get; set; }
        public string SINCREIN_COD_OPERACAO { get; set; }
        public string SINCREIN_NUM_CONTRATO { get; set; }
        public string SINCREIN_CONTRATO_DIGITO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }

        public static R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1 Execute(R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1 r110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1)
        {
            var ths = r110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.SINCREIN_COD_SUREG = result[i++].Value?.ToString();
            dta.SINCREIN_COD_AGENCIA = result[i++].Value?.ToString();
            dta.SINCREIN_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINCREIN_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINCREIN_CONTRATO_DIGITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}