using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1 : QueryBasis<R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVIMENTO_VGAP
            ( NUM_APOLICE,
            COD_SUBGRUPO,
            COD_FONTE,
            NUM_PROPOSTA,
            TIPO_SEGURADO,
            NUM_CERTIFICADO,
            DAC_CERTIFICADO,
            TIPO_INCLUSAO,
            COD_CLIENTE,
            COD_AGENCIADOR,
            COD_CORRETOR,
            COD_PLANOVGAP,
            COD_PLANOAP,
            FAIXA,
            AUTOR_AUM_AUTOMAT,
            TIPO_BENEFICIARIO,
            PERI_PAGAMENTO,
            PERI_RENOVACAO,
            COD_OCUPACAO,
            ESTADO_CIVIL,
            IDE_SEXO,
            COD_PROFISSAO,
            NATURALIDADE,
            OCORR_ENDERECO,
            OCORR_END_COBRAN,
            BCO_COBRANCA,
            AGE_COBRANCA,
            DAC_COBRANCA,
            NUM_MATRICULA,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE,
            VAL_SALARIO,
            TIPO_SALARIO,
            TIPO_PLANO,
            PCT_CONJUGE_VG,
            PCT_CONJUGE_AP,
            QTD_SAL_MORNATU,
            QTD_SAL_MORACID,
            QTD_SAL_INVPERM,
            TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS,
            TAXA_AP_DH,
            TAXA_AP_DIT,
            TAXA_VG,
            IMP_MORNATU_ANT,
            IMP_MORNATU_ATU,
            IMP_MORACID_ANT,
            IMP_MORACID_ATU,
            IMP_INVPERM_ANT,
            IMP_INVPERM_ATU,
            IMP_AMDS_ANT,
            IMP_AMDS_ATU,
            IMP_DH_ANT,
            IMP_DH_ATU,
            IMP_DIT_ANT,
            IMP_DIT_ATU,
            PRM_VG_ANT,
            PRM_VG_ATU,
            PRM_AP_ANT,
            PRM_AP_ATU,
            COD_OPERACAO,
            DATA_OPERACAO,
            COD_SUBGRUPO_TRANS,
            SIT_REGISTRO,
            COD_USUARIO,
            DATA_AVERBACAO,
            DATA_ADMISSAO,
            DATA_INCLUSAO,
            DATA_NASCIMENTO,
            DATA_FATURA,
            DATA_REFERENCIA,
            DATA_MOVIMENTO,
            COD_EMPRESA,
            LOT_EMP_SEGURADO)
            VALUES (:SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-COD-FONTE,
            :FONTES-ULT-PROP-AUTOMAT,
            '1' ,
            :SEGURVGA-NUM-CERTIFICADO,
            ' ' ,
            '1' ,
            :SEGURVGA-COD-CLIENTE,
            :MOVIMVGA-COD-AGENCIADOR,
            0,
            0,
            0,
            1,
            'S' ,
            'N' ,
            1,
            12,
            ' ' ,
            ' ' ,
            ' ' ,
            0,
            ' ' ,
            1,
            1,
            104,
            0,
            ' ' ,
            :MOVIMVGA-NUM-MATRICULA,
            0,
            ' ' ,
            :MOVIMVGA-VAL-SALARIO,
            :MOVIMVGA-TIPO-SALARIO,
            :MOVIMVGA-TIPO-PLANO,
            0,
            0,
            :MOVIMVGA-QTD-SAL-MORNATU,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :MOVIMVGA-TAXA-VG,
            :MOVIMVGA-IMP-MORNATU-ANT,
            :MOVIMVGA-IMP-MORNATU-ATU,
            :MOVIMVGA-IMP-MORACID-ANT,
            :MOVIMVGA-IMP-MORACID-ATU,
            :MOVIMVGA-IMP-INVPERM-ANT,
            :MOVIMVGA-IMP-INVPERM-ATU,
            0,
            0,
            0,
            0,
            0,
            0,
            :MOVIMVGA-PRM-VG-ANT,
            :MOVIMVGA-PRM-VG-ATU,
            0,
            0,
            :MOVIMVGA-COD-OPERACAO,
            :SISTEMAS-DATA-MOV-ABERTO,
            0,
            '1' ,
            'VG9521B' ,
            :MOVIMVGA-DATA-AVERBACAO,
            NULL,
            NULL,
            :CLIENTES-DATA-NASCIMENTO,
            NULL,
            :FATURCON-DATA-REFERENCIA,
            :SEGURVGA-DATA-INIVIGENCIA,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES ({FieldThreatment(this.SEGURVGA_NUM_APOLICE)}, {FieldThreatment(this.SEGURVGA_COD_SUBGRUPO)}, {FieldThreatment(this.SEGURVGA_COD_FONTE)}, {FieldThreatment(this.FONTES_ULT_PROP_AUTOMAT)}, '1' , {FieldThreatment(this.SEGURVGA_NUM_CERTIFICADO)}, ' ' , '1' , {FieldThreatment(this.SEGURVGA_COD_CLIENTE)}, {FieldThreatment(this.MOVIMVGA_COD_AGENCIADOR)}, 0, 0, 0, 1, 'S' , 'N' , 1, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , {FieldThreatment(this.MOVIMVGA_NUM_MATRICULA)}, 0, ' ' , {FieldThreatment(this.MOVIMVGA_VAL_SALARIO)}, {FieldThreatment(this.MOVIMVGA_TIPO_SALARIO)}, {FieldThreatment(this.MOVIMVGA_TIPO_PLANO)}, 0, 0, {FieldThreatment(this.MOVIMVGA_QTD_SAL_MORNATU)}, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.MOVIMVGA_TAXA_VG)}, {FieldThreatment(this.MOVIMVGA_IMP_MORNATU_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_MORNATU_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_MORACID_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_MORACID_ATU)}, {FieldThreatment(this.MOVIMVGA_IMP_INVPERM_ANT)}, {FieldThreatment(this.MOVIMVGA_IMP_INVPERM_ATU)}, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.MOVIMVGA_PRM_VG_ANT)}, {FieldThreatment(this.MOVIMVGA_PRM_VG_ATU)}, 0, 0, {FieldThreatment(this.MOVIMVGA_COD_OPERACAO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 0, '1' , 'VG9521B' , {FieldThreatment(this.MOVIMVGA_DATA_AVERBACAO)}, NULL, NULL, {FieldThreatment(this.CLIENTES_DATA_NASCIMENTO)}, NULL, {FieldThreatment(this.FATURCON_DATA_REFERENCIA)}, {FieldThreatment(this.SEGURVGA_DATA_INIVIGENCIA)}, NULL, NULL)";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string MOVIMVGA_COD_AGENCIADOR { get; set; }
        public string MOVIMVGA_NUM_MATRICULA { get; set; }
        public string MOVIMVGA_VAL_SALARIO { get; set; }
        public string MOVIMVGA_TIPO_SALARIO { get; set; }
        public string MOVIMVGA_TIPO_PLANO { get; set; }
        public string MOVIMVGA_QTD_SAL_MORNATU { get; set; }
        public string MOVIMVGA_TAXA_VG { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ANT { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ATU { get; set; }
        public string MOVIMVGA_IMP_MORACID_ANT { get; set; }
        public string MOVIMVGA_IMP_MORACID_ATU { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ANT { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ATU { get; set; }
        public string MOVIMVGA_PRM_VG_ANT { get; set; }
        public string MOVIMVGA_PRM_VG_ATU { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string MOVIMVGA_DATA_AVERBACAO { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string FATURCON_DATA_REFERENCIA { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }

        public static void Execute(R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1 r6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1)
        {
            var ths = r6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}