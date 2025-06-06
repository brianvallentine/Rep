using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBGE053
{
    public class P2030_CONSULTA_GE149_DB_SELECT_1_Query1 : QueryBasis<P2030_CONSULTA_GE149_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CPF
            , DTH_OPERACAO
            , NOM_SOCIAL
            , IND_TIPO_ACAO
            , IND_USA_NOME_SOCIAL
            , IFNULL( COD_TP_PES_NEGOCIO , 0 )
            , IFNULL( NUM_PROPOSTA , 0 )
            , COD_CANAL_ORIGEM
            , NUM_MATRICULA
            , NOM_PROGRAMA
            , DTH_CADASTRAMENTO
            INTO :GE149-NUM-CPF
            , :GE149-DTH-OPERACAO
            , :GE149-NOM-SOCIAL
            , :GE149-IND-TIPO-ACAO
            , :GE149-IND-USA-NOME-SOCIAL
            , :GE149-COD-TP-PES-NEGOCIO
            , :GE149-NUM-PROPOSTA
            , :GE149-COD-CANAL-ORIGEM
            , :GE149-NUM-MATRICULA
            , :GE149-NOM-PROGRAMA
            , :GE149-DTH-CADASTRAMENTO
            FROM SEGUROS.GE_NOME_SOCIAL
            WHERE NUM_CPF = :GE149-NUM-CPF
            ORDER BY DTH_OPERACAO DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CPF
											, DTH_OPERACAO
											, NOM_SOCIAL
											, IND_TIPO_ACAO
											, IND_USA_NOME_SOCIAL
											, IFNULL( COD_TP_PES_NEGOCIO 
							, 0 )
											, IFNULL( NUM_PROPOSTA 
							, 0 )
											, COD_CANAL_ORIGEM
											, NUM_MATRICULA
											, NOM_PROGRAMA
											, DTH_CADASTRAMENTO
											FROM SEGUROS.GE_NOME_SOCIAL
											WHERE NUM_CPF = '{this.GE149_NUM_CPF}'
											ORDER BY DTH_OPERACAO DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string GE149_NUM_CPF { get; set; }
        public string GE149_DTH_OPERACAO { get; set; }
        public string GE149_NOM_SOCIAL { get; set; }
        public string GE149_IND_TIPO_ACAO { get; set; }
        public string GE149_IND_USA_NOME_SOCIAL { get; set; }
        public string GE149_COD_TP_PES_NEGOCIO { get; set; }
        public string GE149_NUM_PROPOSTA { get; set; }
        public string GE149_COD_CANAL_ORIGEM { get; set; }
        public string GE149_NUM_MATRICULA { get; set; }
        public string GE149_NOM_PROGRAMA { get; set; }
        public string GE149_DTH_CADASTRAMENTO { get; set; }

        public static P2030_CONSULTA_GE149_DB_SELECT_1_Query1 Execute(P2030_CONSULTA_GE149_DB_SELECT_1_Query1 p2030_CONSULTA_GE149_DB_SELECT_1_Query1)
        {
            var ths = p2030_CONSULTA_GE149_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2030_CONSULTA_GE149_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2030_CONSULTA_GE149_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE149_NUM_CPF = result[i++].Value?.ToString();
            dta.GE149_DTH_OPERACAO = result[i++].Value?.ToString();
            dta.GE149_NOM_SOCIAL = result[i++].Value?.ToString();
            dta.GE149_IND_TIPO_ACAO = result[i++].Value?.ToString();
            dta.GE149_IND_USA_NOME_SOCIAL = result[i++].Value?.ToString();
            dta.GE149_COD_TP_PES_NEGOCIO = result[i++].Value?.ToString();
            dta.GE149_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.GE149_COD_CANAL_ORIGEM = result[i++].Value?.ToString();
            dta.GE149_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.GE149_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.GE149_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}