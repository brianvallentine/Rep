using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0720B
{
    public class R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1 : QueryBasis<R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PROPOSTA_SIVPF,
            A.COD_PRODUTO_SIVPF ,
            A.CANAL_PROPOSTA ,
            A.NUM_IDENTIFICACAO
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF,
            :PROPOFID-COD-PRODUTO-SIVPF ,
            :PROPOFID-CANAL-PROPOSTA ,
            :PROPOFID-NUM-IDENTIFICACAO
            FROM SEGUROS.PROPOSTA_FIDELIZ A,
            SEGUROS.IDENTIFICA_RELAC B
            WHERE A.NUM_SICOB =
            :PROPOFID-NUM-PROPOSTA-SIVPF
            AND B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO
            AND A.COD_PRODUTO_SIVPF <> 48
            AND B.COD_RELAC IN (1, 8)
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PROPOSTA_SIVPF
							,
											A.COD_PRODUTO_SIVPF 
							,
											A.CANAL_PROPOSTA 
							,
											A.NUM_IDENTIFICACAO
											FROM SEGUROS.PROPOSTA_FIDELIZ A
							,
											SEGUROS.IDENTIFICA_RELAC B
											WHERE A.NUM_SICOB =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO
											AND A.COD_PRODUTO_SIVPF <> 48
											AND B.COD_RELAC IN (1
							, 8)
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_CANAL_PROPOSTA { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }

        public static R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1 Execute(R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1 r0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1)
        {
            var ths = r0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}