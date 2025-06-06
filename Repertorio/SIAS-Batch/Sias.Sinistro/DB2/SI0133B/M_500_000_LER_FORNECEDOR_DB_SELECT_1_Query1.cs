using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1 : QueryBasis<M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NOME_BANCO, A.NOME_AGENCIA, F.COD_AGENCIA,
            F.NUM_CTA_CORRENTE, F.COD_BANCO
            INTO :BANCOS-NOME-BANCO, :AGENCIAS-NOME-AGENCIA,
            :FORNECED-COD-AGENCIA,
            :FORNECED-NUM-CTA-CORRENTE,
            :FORNECED-COD-BANCO
            FROM SEGUROS.FORNECEDORES F,
            SEGUROS.AGENCIAS A,
            SEGUROS.BANCOS B
            WHERE F.COD_FORNECEDOR = :THIST-CODPSVI
            AND F.COD_BANCO = B.COD_BANCO
            AND F.COD_BANCO = A.COD_BANCO
            AND F.COD_AGENCIA = A.COD_AGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NOME_BANCO
							, A.NOME_AGENCIA
							, F.COD_AGENCIA
							,
											F.NUM_CTA_CORRENTE
							, F.COD_BANCO
											FROM SEGUROS.FORNECEDORES F
							,
											SEGUROS.AGENCIAS A
							,
											SEGUROS.BANCOS B
											WHERE F.COD_FORNECEDOR = '{this.THIST_CODPSVI}'
											AND F.COD_BANCO = B.COD_BANCO
											AND F.COD_BANCO = A.COD_BANCO
											AND F.COD_AGENCIA = A.COD_AGENCIA";

            return query;
        }
        public string BANCOS_NOME_BANCO { get; set; }
        public string AGENCIAS_NOME_AGENCIA { get; set; }
        public string FORNECED_COD_AGENCIA { get; set; }
        public string FORNECED_NUM_CTA_CORRENTE { get; set; }
        public string FORNECED_COD_BANCO { get; set; }
        public string THIST_CODPSVI { get; set; }

        public static M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1 Execute(M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1 m_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1)
        {
            var ths = m_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.BANCOS_NOME_BANCO = result[i++].Value?.ToString();
            dta.AGENCIAS_NOME_AGENCIA = result[i++].Value?.ToString();
            dta.FORNECED_COD_AGENCIA = result[i++].Value?.ToString();
            dta.FORNECED_NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.FORNECED_COD_BANCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}