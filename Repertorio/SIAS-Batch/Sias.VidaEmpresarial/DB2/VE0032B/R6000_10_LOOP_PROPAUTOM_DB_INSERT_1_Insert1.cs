using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0032B
{
    public class R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1 : QueryBasis<R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVIMENTO_VGAP
            ( NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_FONTE ,
            NUM_PROPOSTA ,
            TIPO_SEGURADO ,
            NUM_CERTIFICADO ,
            DAC_CERTIFICADO ,
            TIPO_INCLUSAO ,
            COD_CLIENTE ,
            COD_AGENCIADOR ,
            COD_CORRETOR ,
            COD_PLANOVGAP ,
            COD_PLANOAP ,
            FAIXA ,
            AUTOR_AUM_AUTOMAT ,
            TIPO_BENEFICIARIO ,
            PERI_PAGAMENTO ,
            PERI_RENOVACAO ,
            COD_OCUPACAO ,
            ESTADO_CIVIL ,
            IDE_SEXO ,
            COD_PROFISSAO ,
            NATURALIDADE ,
            OCORR_ENDERECO ,
            OCORR_END_COBRAN ,
            BCO_COBRANCA ,
            AGE_COBRANCA ,
            DAC_COBRANCA ,
            NUM_MATRICULA ,
            NUM_CTA_CORRENTE ,
            DAC_CTA_CORRENTE ,
            VAL_SALARIO ,
            TIPO_SALARIO ,
            TIPO_PLANO ,
            PCT_CONJUGE_VG ,
            PCT_CONJUGE_AP ,
            QTD_SAL_MORNATU ,
            QTD_SAL_MORACID ,
            QTD_SAL_INVPERM ,
            TAXA_AP_MORACID ,
            TAXA_AP_INVPERM ,
            TAXA_AP_AMDS ,
            TAXA_AP_DH ,
            TAXA_AP_DIT ,
            TAXA_VG ,
            IMP_MORNATU_ANT ,
            IMP_MORNATU_ATU ,
            IMP_MORACID_ANT ,
            IMP_MORACID_ATU ,
            IMP_INVPERM_ANT ,
            IMP_INVPERM_ATU ,
            IMP_AMDS_ANT ,
            IMP_AMDS_ATU ,
            IMP_DH_ANT ,
            IMP_DH_ATU ,
            IMP_DIT_ANT ,
            IMP_DIT_ATU ,
            PRM_VG_ANT ,
            PRM_VG_ATU ,
            PRM_AP_ANT ,
            PRM_AP_ATU ,
            COD_OPERACAO ,
            DATA_OPERACAO ,
            COD_SUBGRUPO_TRANS ,
            SIT_REGISTRO ,
            COD_USUARIO ,
            DATA_AVERBACAO ,
            DATA_ADMISSAO ,
            DATA_INCLUSAO ,
            DATA_NASCIMENTO ,
            DATA_FATURA ,
            DATA_REFERENCIA ,
            DATA_MOVIMENTO ,
            COD_EMPRESA ,
            LOT_EMP_SEGURADO)
            VALUES (:SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-COD-FONTE,
            :FONTES-ULT-PROP-AUTOMAT,
            '1' ,
            :SEGURVGA-NUM-CERTIFICADO,
            ' ' ,
            :SEGURVGA-TIPO-INCLUSAO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-COD-AGENCIADOR,
            0,
            0,
            0,
            0,
            'S' ,
            'N' ,
            :MOVIMVGA-PERI-PAGAMENTO,
            12,
            ' ' ,
            ' ' ,
            ' ' ,
            0,
            ' ' ,
            1,
            1,
            104,
            :CONTACOR-COD-AGENCIA,
            ' ' ,
            :SEGURVGA-NUM-MATRICULA,
            :CONTACOR-NUM-CTA-CORRENTE,
            :CONTACOR-DAC-CTA-CORRENTE,
            0,
            ' ' ,
            '1' ,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0COBA-IMPMORNATU,
            :V0COBA-IMPMORNATU,
            :V0COBA-IMPMORACID,
            :V0COBA-IMPMORACID,
            :V0COBA-IMPINVPERM,
            :V0COBA-IMPINVPERM,
            0,
            0,
            0,
            0,
            :V0COBA-IMPDIT,
            :V0COBA-IMPDIT,
            :V0COBA-PRMVG,
            :V0COBA-PRMVG,
            :V0COBA-PRMAP,
            :V0COBA-PRMAP,
            :MOVIMVGA-COD-OPERACAO,
            CURRENT DATE,
            0,
            '1' ,
            :RELATORI-COD-USUARIO,
            CURRENT DATE,
            NULL,
            NULL,
            NULL,
            NULL,
            :FATURCON-DATA-REFERENCIA,
            :RELATORI-DATA-SOLICITACAO,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES ({FieldThreatment(this.SEGURVGA_NUM_APOLICE)}, {FieldThreatment(this.SEGURVGA_COD_SUBGRUPO)}, {FieldThreatment(this.SEGURVGA_COD_FONTE)}, {FieldThreatment(this.FONTES_ULT_PROP_AUTOMAT)}, '1' , {FieldThreatment(this.SEGURVGA_NUM_CERTIFICADO)}, ' ' , {FieldThreatment(this.SEGURVGA_TIPO_INCLUSAO)}, {FieldThreatment(this.SEGURVGA_COD_CLIENTE)}, {FieldThreatment(this.SEGURVGA_COD_AGENCIADOR)}, 0, 0, 0, 0, 'S' , 'N' , {FieldThreatment(this.MOVIMVGA_PERI_PAGAMENTO)}, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, {FieldThreatment(this.CONTACOR_COD_AGENCIA)}, ' ' , {FieldThreatment(this.SEGURVGA_NUM_MATRICULA)}, {FieldThreatment(this.CONTACOR_NUM_CTA_CORRENTE)}, {FieldThreatment(this.CONTACOR_DAC_CTA_CORRENTE)}, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0COBA_IMPMORNATU)}, {FieldThreatment(this.V0COBA_IMPMORNATU)}, {FieldThreatment(this.V0COBA_IMPMORACID)}, {FieldThreatment(this.V0COBA_IMPMORACID)}, {FieldThreatment(this.V0COBA_IMPINVPERM)}, {FieldThreatment(this.V0COBA_IMPINVPERM)}, 0, 0, 0, 0, {FieldThreatment(this.V0COBA_IMPDIT)}, {FieldThreatment(this.V0COBA_IMPDIT)}, {FieldThreatment(this.V0COBA_PRMVG)}, {FieldThreatment(this.V0COBA_PRMVG)}, {FieldThreatment(this.V0COBA_PRMAP)}, {FieldThreatment(this.V0COBA_PRMAP)}, {FieldThreatment(this.MOVIMVGA_COD_OPERACAO)}, CURRENT DATE, 0, '1' , {FieldThreatment(this.RELATORI_COD_USUARIO)}, CURRENT DATE, NULL, NULL, NULL, NULL, {FieldThreatment(this.FATURCON_DATA_REFERENCIA)}, {FieldThreatment(this.RELATORI_DATA_SOLICITACAO)}, NULL, NULL)";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_TIPO_INCLUSAO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_COD_AGENCIADOR { get; set; }
        public string MOVIMVGA_PERI_PAGAMENTO { get; set; }
        public string CONTACOR_COD_AGENCIA { get; set; }
        public string SEGURVGA_NUM_MATRICULA { get; set; }
        public string CONTACOR_NUM_CTA_CORRENTE { get; set; }
        public string CONTACOR_DAC_CTA_CORRENTE { get; set; }
        public string V0COBA_IMPMORNATU { get; set; }
        public string V0COBA_IMPMORACID { get; set; }
        public string V0COBA_IMPINVPERM { get; set; }
        public string V0COBA_IMPDIT { get; set; }
        public string V0COBA_PRMVG { get; set; }
        public string V0COBA_PRMAP { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string FATURCON_DATA_REFERENCIA { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }

        public static void Execute(R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1 r6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1)
        {
            var ths = r6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}