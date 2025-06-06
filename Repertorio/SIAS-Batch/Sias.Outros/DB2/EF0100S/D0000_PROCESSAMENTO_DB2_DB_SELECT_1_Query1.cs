using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.EF0100S
{
    public class D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 : QueryBasis<D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE,
            NOME_LOGRADOURO,
            VALUE(NUM_IMOVEL, '00000' ),
            VALUE(COMPL_ENDER, ' ' ),
            VALUE(BAIRRO, ' ' ),
            CIDADE,
            UF,
            CEP
            INTO :LS-V0END-COD-CLIENTE ,
            :LS-V0END-ENDER-IMOVEL ,
            :LS-V0END-NUM-IMOVEL ,
            :LS-V0END-COMPL-IMOVEL ,
            :LS-V0END-BAIRRO-IMOVEL,
            :LS-V0END-CIDADE-IMOVEL,
            :LS-V0END-UF-IMOVEL ,
            :LS-V0END-CEP-IMOVEL
            FROM SEGUROS.V0ENDERECO_HABIT
            WHERE COD_PRODUTO = 6802
            AND COD_CLIENTE = 528094
            AND OPERACAO = 0
            AND PONTO_VENDA = 0
            AND NUM_CONTRATO = :LS-V0HABIT4-NUM-FIAP
            AND DATA_SIT_INI <= :LS-V0MEST-DATORR
            AND VALUE(DATA_SIT_FIM,DATE( '9999-12-31' ))
            >= :LS-V0MEST-DATORR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							,
											NOME_LOGRADOURO
							,
											VALUE(NUM_IMOVEL
							, '00000' )
							,
											VALUE(COMPL_ENDER
							, ' ' )
							,
											VALUE(BAIRRO
							, ' ' )
							,
											CIDADE
							,
											UF
							,
											CEP
											FROM SEGUROS.V0ENDERECO_HABIT
											WHERE COD_PRODUTO = 6802
											AND COD_CLIENTE = 528094
											AND OPERACAO = 0
											AND PONTO_VENDA = 0
											AND NUM_CONTRATO = '{this.LS_V0HABIT4_NUM_FIAP}'
											AND DATA_SIT_INI <= '{this.LS_V0MEST_DATORR}'
											AND VALUE(DATA_SIT_FIM
							,DATE( '9999-12-31' ))
											>= '{this.LS_V0MEST_DATORR}'";

            return query;
        }
        public string LS_V0END_COD_CLIENTE { get; set; }
        public string LS_V0END_ENDER_IMOVEL { get; set; }
        public string LS_V0END_NUM_IMOVEL { get; set; }
        public string LS_V0END_COMPL_IMOVEL { get; set; }
        public string LS_V0END_BAIRRO_IMOVEL { get; set; }
        public string LS_V0END_CIDADE_IMOVEL { get; set; }
        public string LS_V0END_UF_IMOVEL { get; set; }
        public string LS_V0END_CEP_IMOVEL { get; set; }
        public string LS_V0HABIT4_NUM_FIAP { get; set; }
        public string LS_V0MEST_DATORR { get; set; }

        public static D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 Execute(D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1)
        {
            var ths = d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1();
            var i = 0;
            dta.LS_V0END_COD_CLIENTE = result[i++].Value?.ToString();
            dta.LS_V0END_ENDER_IMOVEL = result[i++].Value?.ToString();
            dta.LS_V0END_NUM_IMOVEL = result[i++].Value?.ToString();
            dta.LS_V0END_COMPL_IMOVEL = result[i++].Value?.ToString();
            dta.LS_V0END_BAIRRO_IMOVEL = result[i++].Value?.ToString();
            dta.LS_V0END_CIDADE_IMOVEL = result[i++].Value?.ToString();
            dta.LS_V0END_UF_IMOVEL = result[i++].Value?.ToString();
            dta.LS_V0END_CEP_IMOVEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}