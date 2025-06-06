using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 : QueryBasis<R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PROPOSTAS_VA
            (NUM_CERTIFICADO ,
            COD_PRODUTO ,
            COD_CLIENTE ,
            OCOREND ,
            COD_FONTE ,
            AGE_COBRANCA ,
            OPCAO_COBERTURA ,
            DATA_QUITACAO ,
            COD_AGE_VENDEDOR ,
            OPE_CONTA_VENDEDOR,
            NUM_CONTA_VENDEDOR,
            DIG_CONTA_VENDEDOR,
            NUM_MATRI_VENDEDOR,
            COD_OPERACAO ,
            PROFISSAO ,
            DTINCLUS ,
            DATA_MOVIMENTO ,
            SIT_REGISTRO ,
            NUM_APOLICE ,
            COD_SUBGRUPO ,
            OCORR_HISTORICO ,
            NRPRIPARATZ ,
            QTDPARATZ ,
            DTPROXVEN ,
            NUM_PARCELA ,
            DATA_VENCIMENTO ,
            SIT_INTERFACE ,
            DTFENAE ,
            COD_USUARIO ,
            TIMESTAMP ,
            IDADE ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OPCAO_MARCADA ,
            SIGLA_CRM ,
            COD_CRM ,
            APOS_INVALIDEZ ,
            ASSINATURA ,
            ACATAMENTO ,
            NOME_ESPOSA ,
            DTNASC_ESPOSA ,
            PROFIS_ESPOSA ,
            DPS_TITULAR ,
            DPS_ESPOSA ,
            NUM_MATRICULA ,
            GRAU_PARENTESCO ,
            DATA_ADMISSAO ,
            NUM_PROPOSTA ,
            EM_ATIVIDADE ,
            LOC_ATIVIDADE ,
            INFO_COMPLEMENTAR ,
            NRMALADIR ,
            NRCERTIFANT ,
            COD_CCT )
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :PROPOVA-COD-PRODUTO,
            :PROPOVA-COD-CLIENTE,
            :PROPOVA-OCOREND,
            :PROPOVA-COD-FONTE,
            :PROPOVA-AGE-COBRANCA,
            :PROPOVA-OPCAO-COBERTURA,
            :PROPOVA-DATA-QUITACAO,
            :PROPOVA-COD-AGE-VENDEDOR,
            :PROPOVA-OPE-CONTA-VENDEDOR,
            :PROPOVA-NUM-CONTA-VENDEDOR,
            :PROPOVA-DIG-CONTA-VENDEDOR,
            :PROPOVA-NUM-MATRI-VENDEDOR,
            :PROPOVA-COD-OPERACAO,
            :PROPOVA-PROFISSAO,
            :PROPOVA-DTINCLUS,
            :PROPOVA-DATA-MOVIMENTO,
            :PROPOVA-SIT-REGISTRO,
            :PROPOVA-NUM-APOLICE,
            :PROPOVA-COD-SUBGRUPO,
            :PROPOVA-OCORR-HISTORICO,
            :PROPOVA-NRPRIPARATZ,
            :PROPOVA-QTDPARATZ,
            :PROPOVA-DTPROXVEN,
            :PROPOVA-NUM-PARCELA,
            :PROPOVA-DATA-VENCIMENTO,
            :PROPOVA-SIT-INTERFACE,
            :PROPOVA-DTFENAE,
            :PROPOVA-COD-USUARIO,
            CURRENT TIMESTAMP,
            :PROPOVA-IDADE,
            :PROPOVA-IDE-SEXO,
            :PROPOVA-ESTADO-CIVIL,
            :PROPOVA-OPCAO-MARCADA,
            :PROPOVA-SIGLA-CRM:VIND-SIGLA-CRM,
            :PROPOVA-COD-CRM:VIND-COD-CRM,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :PROPOVA-DPS-TITULAR,
            NULL,
            :PROPOVA-NUM-MATRICULA,
            NULL,
            NULL,
            :PROPOVA-NUM-PROPOSTA,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTAS_VA (NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR, NUM_CONTA_VENDEDOR, DIG_CONTA_VENDEDOR, NUM_MATRI_VENDEDOR, COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT ) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.PROPOVA_COD_PRODUTO)}, {FieldThreatment(this.PROPOVA_COD_CLIENTE)}, {FieldThreatment(this.PROPOVA_OCOREND)}, {FieldThreatment(this.PROPOVA_COD_FONTE)}, {FieldThreatment(this.PROPOVA_AGE_COBRANCA)}, {FieldThreatment(this.PROPOVA_OPCAO_COBERTURA)}, {FieldThreatment(this.PROPOVA_DATA_QUITACAO)}, {FieldThreatment(this.PROPOVA_COD_AGE_VENDEDOR)}, {FieldThreatment(this.PROPOVA_OPE_CONTA_VENDEDOR)}, {FieldThreatment(this.PROPOVA_NUM_CONTA_VENDEDOR)}, {FieldThreatment(this.PROPOVA_DIG_CONTA_VENDEDOR)}, {FieldThreatment(this.PROPOVA_NUM_MATRI_VENDEDOR)}, {FieldThreatment(this.PROPOVA_COD_OPERACAO)}, {FieldThreatment(this.PROPOVA_PROFISSAO)}, {FieldThreatment(this.PROPOVA_DTINCLUS)}, {FieldThreatment(this.PROPOVA_DATA_MOVIMENTO)}, {FieldThreatment(this.PROPOVA_SIT_REGISTRO)}, {FieldThreatment(this.PROPOVA_NUM_APOLICE)}, {FieldThreatment(this.PROPOVA_COD_SUBGRUPO)}, {FieldThreatment(this.PROPOVA_OCORR_HISTORICO)}, {FieldThreatment(this.PROPOVA_NRPRIPARATZ)}, {FieldThreatment(this.PROPOVA_QTDPARATZ)}, {FieldThreatment(this.PROPOVA_DTPROXVEN)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, {FieldThreatment(this.PROPOVA_DATA_VENCIMENTO)}, {FieldThreatment(this.PROPOVA_SIT_INTERFACE)}, {FieldThreatment(this.PROPOVA_DTFENAE)}, {FieldThreatment(this.PROPOVA_COD_USUARIO)}, CURRENT TIMESTAMP, {FieldThreatment(this.PROPOVA_IDADE)}, {FieldThreatment(this.PROPOVA_IDE_SEXO)}, {FieldThreatment(this.PROPOVA_ESTADO_CIVIL)}, {FieldThreatment(this.PROPOVA_OPCAO_MARCADA)},  {FieldThreatment((this.VIND_SIGLA_CRM?.ToInt() == -1 ? null : this.PROPOVA_SIGLA_CRM))},  {FieldThreatment((this.VIND_COD_CRM?.ToInt() == -1 ? null : this.PROPOVA_COD_CRM))}, NULL, NULL, NULL, NULL, NULL, NULL, {FieldThreatment(this.PROPOVA_DPS_TITULAR)}, NULL, {FieldThreatment(this.PROPOVA_NUM_MATRICULA)}, NULL, NULL, {FieldThreatment(this.PROPOVA_NUM_PROPOSTA)}, NULL, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_OPCAO_COBERTURA { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_COD_AGE_VENDEDOR { get; set; }
        public string PROPOVA_OPE_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_NUM_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_DIG_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }
        public string PROPOVA_COD_OPERACAO { get; set; }
        public string PROPOVA_PROFISSAO { get; set; }
        public string PROPOVA_DTINCLUS { get; set; }
        public string PROPOVA_DATA_MOVIMENTO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NRPRIPARATZ { get; set; }
        public string PROPOVA_QTDPARATZ { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string PROPOVA_SIT_INTERFACE { get; set; }
        public string PROPOVA_DTFENAE { get; set; }
        public string PROPOVA_COD_USUARIO { get; set; }
        public string PROPOVA_IDADE { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string PROPOVA_ESTADO_CIVIL { get; set; }
        public string PROPOVA_OPCAO_MARCADA { get; set; }
        public string PROPOVA_SIGLA_CRM { get; set; }
        public string VIND_SIGLA_CRM { get; set; }
        public string PROPOVA_COD_CRM { get; set; }
        public string VIND_COD_CRM { get; set; }
        public string PROPOVA_DPS_TITULAR { get; set; }
        public string PROPOVA_NUM_MATRICULA { get; set; }
        public string PROPOVA_NUM_PROPOSTA { get; set; }

        public static void Execute(R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 r3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1)
        {
            var ths = r3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}