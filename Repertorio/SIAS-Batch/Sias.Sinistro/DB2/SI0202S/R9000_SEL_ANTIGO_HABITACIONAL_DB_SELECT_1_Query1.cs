using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202S
{
    public class R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1 : QueryBasis<R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(TIPO_LOGRADOURO, ' ' ) || ' ' ||
            NOME_LOGRADOURO || ' ' ||
            VALUE(NUM_IMOVEL, ' ' ) || ' ' ||
            VALUE(COMPL_ENDER, ' ' )
            ,VALUE(BAIRRO, ' ' )
            ,CIDADE
            ,UF
            ,CEP
            INTO :W-ENDHABIT-ENDERECO
            ,:ENDHABIT-BAIRRO
            ,:ENDHABIT-CIDADE
            ,:ENDHABIT-UF
            ,:ENDHABIT-CEP
            FROM SEGUROS.ENDERECO_HABIT
            WHERE OPERACAO = :ENDHABIT-OPERACAO
            AND PONTO_VENDA = :ENDHABIT-PONTO-VENDA
            AND NUM_CONTRATO = :ENDHABIT-NUM-CONTRATO
            AND OCORR_ENDER = 1
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(TIPO_LOGRADOURO
							, ' ' ) || ' ' ||
											NOME_LOGRADOURO || ' ' ||
											VALUE(NUM_IMOVEL
							, ' ' ) || ' ' ||
											VALUE(COMPL_ENDER
							, ' ' )
											,VALUE(BAIRRO
							, ' ' )
											,CIDADE
											,UF
											,CEP
											FROM SEGUROS.ENDERECO_HABIT
											WHERE OPERACAO = '{this.ENDHABIT_OPERACAO}'
											AND PONTO_VENDA = '{this.ENDHABIT_PONTO_VENDA}'
											AND NUM_CONTRATO = '{this.ENDHABIT_NUM_CONTRATO}'
											AND OCORR_ENDER = 1
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string W_ENDHABIT_ENDERECO { get; set; }
        public string ENDHABIT_BAIRRO { get; set; }
        public string ENDHABIT_CIDADE { get; set; }
        public string ENDHABIT_UF { get; set; }
        public string ENDHABIT_CEP { get; set; }
        public string ENDHABIT_NUM_CONTRATO { get; set; }
        public string ENDHABIT_PONTO_VENDA { get; set; }
        public string ENDHABIT_OPERACAO { get; set; }

        public static R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1 Execute(R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1 r9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1)
        {
            var ths = r9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_ENDHABIT_ENDERECO = result[i++].Value?.ToString();
            dta.ENDHABIT_BAIRRO = result[i++].Value?.ToString();
            dta.ENDHABIT_CIDADE = result[i++].Value?.ToString();
            dta.ENDHABIT_UF = result[i++].Value?.ToString();
            dta.ENDHABIT_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}