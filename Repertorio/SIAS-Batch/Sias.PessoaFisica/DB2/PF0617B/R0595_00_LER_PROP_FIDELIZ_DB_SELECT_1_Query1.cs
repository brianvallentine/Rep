using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_PROPOSTA ,
            CANAL_PROPOSTA ,
            ORIGEM_PROPOSTA ,
            COD_PRODUTO_SIVPF ,
            NUM_IDENTIFICACAO ,
            NUM_SICOB
            INTO :PROPOFID-SIT-PROPOSTA ,
            :PROPOFID-CANAL-PROPOSTA ,
            :PROPOFID-ORIGEM-PROPOSTA ,
            :PROPOFID-COD-PRODUTO-SIVPF ,
            :PROPOFID-NUM-IDENTIFICACAO ,
            :PROPOFID-NUM-SICOB
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_PROPOSTA 
							,
											CANAL_PROPOSTA 
							,
											ORIGEM_PROPOSTA 
							,
											COD_PRODUTO_SIVPF 
							,
											NUM_IDENTIFICACAO 
							,
											NUM_SICOB
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 r0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}