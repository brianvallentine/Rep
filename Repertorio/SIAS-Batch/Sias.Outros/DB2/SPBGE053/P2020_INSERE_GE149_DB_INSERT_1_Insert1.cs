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
    public class P2020_INSERE_GE149_DB_INSERT_1_Insert1 : QueryBasis<P2020_INSERE_GE149_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_NOME_SOCIAL
            ( NUM_CPF
            , DTH_OPERACAO
            , NOM_SOCIAL
            , IND_TIPO_ACAO
            , IND_USA_NOME_SOCIAL
            , COD_TP_PES_NEGOCIO
            , NUM_PROPOSTA
            , COD_CANAL_ORIGEM
            , NUM_MATRICULA
            , NOM_PROGRAMA
            , DTH_CADASTRAMENTO
            )
            VALUES
            ( :GE149-NUM-CPF
            , CASE :GE149-DTH-OPERACAO
            WHEN '0001-01-01-00.00.00.000000' THEN
            CURRENT TIMESTAMP
            ELSE
            :GE149-DTH-OPERACAO
            END
            , :GE149-NOM-SOCIAL
            , :GE149-IND-TIPO-ACAO
            , :GE149-IND-USA-NOME-SOCIAL
            , CASE :GE149-COD-TP-PES-NEGOCIO
            WHEN 0 THEN
            NULL
            ELSE
            :GE149-COD-TP-PES-NEGOCIO
            END
            , :GE149-NUM-PROPOSTA
            , :GE149-COD-CANAL-ORIGEM
            , :GE149-NUM-MATRICULA
            , :GE149-NOM-PROGRAMA
            , CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_NOME_SOCIAL ( NUM_CPF , DTH_OPERACAO , NOM_SOCIAL , IND_TIPO_ACAO , IND_USA_NOME_SOCIAL , COD_TP_PES_NEGOCIO , NUM_PROPOSTA , COD_CANAL_ORIGEM , NUM_MATRICULA , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.GE149_NUM_CPF)} , CASE {FieldThreatment(this.GE149_DTH_OPERACAO)} WHEN '0001-01-01-00.00.00.000000' THEN CURRENT TIMESTAMP ELSE {FieldThreatment(this.GE149_DTH_OPERACAO)} END , {FieldThreatment(this.GE149_NOM_SOCIAL)} , {FieldThreatment(this.GE149_IND_TIPO_ACAO)} , {FieldThreatment(this.GE149_IND_USA_NOME_SOCIAL)} , CASE {FieldTreatmentInteger(this.GE149_COD_TP_PES_NEGOCIO)} WHEN 0 THEN NULL ELSE {FieldTreatmentInteger(this.GE149_COD_TP_PES_NEGOCIO)} END , {FieldThreatment(this.GE149_NUM_PROPOSTA)} , {FieldThreatment(this.GE149_COD_CANAL_ORIGEM)} , {FieldThreatment(this.GE149_NUM_MATRICULA)} , {FieldThreatment(this.GE149_NOM_PROGRAMA)} , CURRENT TIMESTAMP )";

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

        public static void Execute(P2020_INSERE_GE149_DB_INSERT_1_Insert1 p2020_INSERE_GE149_DB_INSERT_1_Insert1)
        {
            var ths = p2020_INSERE_GE149_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P2020_INSERE_GE149_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}