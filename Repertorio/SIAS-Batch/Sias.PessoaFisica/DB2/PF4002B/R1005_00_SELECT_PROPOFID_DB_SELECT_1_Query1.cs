using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF4002B
{
    public class R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_IDENTIFICACAO ,
            SIT_PROPOSTA ,
            CANAL_PROPOSTA ,
            ORIGEM_PROPOSTA ,
            SITUACAO_ENVIO ,
            COD_PRODUTO_SIVPF ,
            SITUACAO_ENVIO ,
            DATA_PROPOSTA ,
            NUM_PROPOSTA_SIVPF,
            VAL_PAGO
            INTO
            :PROPOFID-NUM-IDENTIFICACAO ,
            :PROPOFID-SIT-PROPOSTA ,
            :PROPOFID-CANAL-PROPOSTA ,
            :PROPOFID-ORIGEM-PROPOSTA ,
            :PROPOFID-SITUACAO-ENVIO ,
            :PROPOFID-COD-PRODUTO-SIVPF ,
            :PROPOFID-SITUACAO-ENVIO ,
            :PROPOFID-DATA-PROPOSTA ,
            :PROPOFID-NUM-PROPOSTA-SIVPF,
            :PROPOFID-VAL-PAGO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :PROPOFID-NUM-PROPOSTA-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_IDENTIFICACAO 
							,
											SIT_PROPOSTA 
							,
											CANAL_PROPOSTA 
							,
											ORIGEM_PROPOSTA 
							,
											SITUACAO_ENVIO 
							,
											COD_PRODUTO_SIVPF 
							,
											SITUACAO_ENVIO 
							,
											DATA_PROPOSTA 
							,
											NUM_PROPOSTA_SIVPF
							,
											VAL_PAGO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }

        public static R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_SITUACAO_ENVIO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            return dta;
        }

    }
}