using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1 : QueryBasis<R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SIT_PROPOSTA,
            DATA_PROPOSTA,
            NUM_IDENTIFICACAO,
            COD_EMPRESA_SIVPF,
            COD_PRODUTO_SIVPF,
            CANAL_PROPOSTA ,
            ORIGEM_PROPOSTA ,
            SITUACAO_ENVIO ,
            NUM_PROPOSTA_SIVPF
            INTO
            :PROPOFID-SIT-PROPOSTA,
            :PROPOFID-DATA-PROPOSTA,
            :PROPOFID-NUM-IDENTIFICACAO,
            :PROPOFID-COD-EMPRESA-SIVPF,
            :PROPOFID-COD-PRODUTO-SIVPF,
            :PROPOFID-CANAL-PROPOSTA ,
            :PROPOFID-ORIGEM-PROPOSTA ,
            :PROPOFID-SITUACAO-ENVIO ,
            :PROPOFID-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NRCERTIFANT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIT_PROPOSTA
							,
											DATA_PROPOSTA
							,
											NUM_IDENTIFICACAO
							,
											COD_EMPRESA_SIVPF
							,
											COD_PRODUTO_SIVPF
							,
											CANAL_PROPOSTA 
							,
											ORIGEM_PROPOSTA 
							,
											SITUACAO_ENVIO 
							,
											NUM_PROPOSTA_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOVA_NRCERTIFANT}'
											WITH UR";

            return query;
        }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_SITUACAO_ENVIO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOVA_NRCERTIFANT { get; set; }

        public static R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1 Execute(R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1 r1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1)
        {
            var ths = r1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_SITUACAO_ENVIO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}