using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( :RELATORI-COD-USUARIO
            ,:RELATORI-DATA-SOLICITACAO
            ,:RELATORI-IDE-SISTEMA
            ,:RELATORI-COD-RELATORIO
            ,:RELATORI-NUM-COPIAS
            ,:RELATORI-QUANTIDADE
            ,:RELATORI-PERI-INICIAL
            ,:RELATORI-PERI-FINAL
            ,:RELATORI-DATA-REFERENCIA
            ,:RELATORI-MES-REFERENCIA
            ,:RELATORI-ANO-REFERENCIA
            ,:RELATORI-ORGAO-EMISSOR
            ,:RELATORI-COD-FONTE
            ,:RELATORI-COD-PRODUTOR
            ,:RELATORI-RAMO-EMISSOR
            ,:RELATORI-COD-MODALIDADE
            ,:RELATORI-COD-CONGENERE
            ,:RELATORI-NUM-APOLICE
            ,:RELATORI-NUM-ENDOSSO
            ,:RELATORI-NUM-PARCELA
            ,:RELATORI-NUM-CERTIFICADO
            ,:RELATORI-NUM-TITULO
            ,:RELATORI-COD-SUBGRUPO
            ,:RELATORI-COD-OPERACAO
            ,:RELATORI-COD-PLANO
            ,:RELATORI-OCORR-HISTORICO
            ,:RELATORI-NUM-APOL-LIDER
            ,:RELATORI-ENDOS-LIDER
            ,:RELATORI-NUM-PARC-LIDER
            ,:RELATORI-NUM-SINISTRO
            ,:RELATORI-NUM-SINI-LIDER
            ,:RELATORI-NUM-ORDEM
            ,:RELATORI-COD-MOEDA
            ,:RELATORI-TIPO-CORRECAO
            ,:RELATORI-SIT-REGISTRO
            ,:RELATORI-IND-PREV-DEFINIT
            ,:RELATORI-IND-ANAL-RESUMO
            ,:RELATORI-COD-EMPRESA
            ,:RELATORI-PERI-RENOVACAO
            ,:RELATORI-PCT-AUMENTO
            , CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS VALUES ( {FieldThreatment(this.RELATORI_COD_USUARIO)} ,{FieldThreatment(this.RELATORI_DATA_SOLICITACAO)} ,{FieldThreatment(this.RELATORI_IDE_SISTEMA)} ,{FieldThreatment(this.RELATORI_COD_RELATORIO)} ,{FieldThreatment(this.RELATORI_NUM_COPIAS)} ,{FieldThreatment(this.RELATORI_QUANTIDADE)} ,{FieldThreatment(this.RELATORI_PERI_INICIAL)} ,{FieldThreatment(this.RELATORI_PERI_FINAL)} ,{FieldThreatment(this.RELATORI_DATA_REFERENCIA)} ,{FieldThreatment(this.RELATORI_MES_REFERENCIA)} ,{FieldThreatment(this.RELATORI_ANO_REFERENCIA)} ,{FieldThreatment(this.RELATORI_ORGAO_EMISSOR)} ,{FieldThreatment(this.RELATORI_COD_FONTE)} ,{FieldThreatment(this.RELATORI_COD_PRODUTOR)} ,{FieldThreatment(this.RELATORI_RAMO_EMISSOR)} ,{FieldThreatment(this.RELATORI_COD_MODALIDADE)} ,{FieldThreatment(this.RELATORI_COD_CONGENERE)} ,{FieldThreatment(this.RELATORI_NUM_APOLICE)} ,{FieldThreatment(this.RELATORI_NUM_ENDOSSO)} ,{FieldThreatment(this.RELATORI_NUM_PARCELA)} ,{FieldThreatment(this.RELATORI_NUM_CERTIFICADO)} ,{FieldThreatment(this.RELATORI_NUM_TITULO)} ,{FieldThreatment(this.RELATORI_COD_SUBGRUPO)} ,{FieldThreatment(this.RELATORI_COD_OPERACAO)} ,{FieldThreatment(this.RELATORI_COD_PLANO)} ,{FieldThreatment(this.RELATORI_OCORR_HISTORICO)} ,{FieldThreatment(this.RELATORI_NUM_APOL_LIDER)} ,{FieldThreatment(this.RELATORI_ENDOS_LIDER)} ,{FieldThreatment(this.RELATORI_NUM_PARC_LIDER)} ,{FieldThreatment(this.RELATORI_NUM_SINISTRO)} ,{FieldThreatment(this.RELATORI_NUM_SINI_LIDER)} ,{FieldThreatment(this.RELATORI_NUM_ORDEM)} ,{FieldThreatment(this.RELATORI_COD_MOEDA)} ,{FieldThreatment(this.RELATORI_TIPO_CORRECAO)} ,{FieldThreatment(this.RELATORI_SIT_REGISTRO)} ,{FieldThreatment(this.RELATORI_IND_PREV_DEFINIT)} ,{FieldThreatment(this.RELATORI_IND_ANAL_RESUMO)} ,{FieldThreatment(this.RELATORI_COD_EMPRESA)} ,{FieldThreatment(this.RELATORI_PERI_RENOVACAO)} ,{FieldThreatment(this.RELATORI_PCT_AUMENTO)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string RELATORI_QUANTIDADE { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string RELATORI_MES_REFERENCIA { get; set; }
        public string RELATORI_ANO_REFERENCIA { get; set; }
        public string RELATORI_ORGAO_EMISSOR { get; set; }
        public string RELATORI_COD_FONTE { get; set; }
        public string RELATORI_COD_PRODUTOR { get; set; }
        public string RELATORI_RAMO_EMISSOR { get; set; }
        public string RELATORI_COD_MODALIDADE { get; set; }
        public string RELATORI_COD_CONGENERE { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_COD_PLANO { get; set; }
        public string RELATORI_OCORR_HISTORICO { get; set; }
        public string RELATORI_NUM_APOL_LIDER { get; set; }
        public string RELATORI_ENDOS_LIDER { get; set; }
        public string RELATORI_NUM_PARC_LIDER { get; set; }
        public string RELATORI_NUM_SINISTRO { get; set; }
        public string RELATORI_NUM_SINI_LIDER { get; set; }
        public string RELATORI_NUM_ORDEM { get; set; }
        public string RELATORI_COD_MOEDA { get; set; }
        public string RELATORI_TIPO_CORRECAO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_IND_PREV_DEFINIT { get; set; }
        public string RELATORI_IND_ANAL_RESUMO { get; set; }
        public string RELATORI_COD_EMPRESA { get; set; }
        public string RELATORI_PERI_RENOVACAO { get; set; }
        public string RELATORI_PCT_AUMENTO { get; set; }

        public static void Execute(R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 r8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}