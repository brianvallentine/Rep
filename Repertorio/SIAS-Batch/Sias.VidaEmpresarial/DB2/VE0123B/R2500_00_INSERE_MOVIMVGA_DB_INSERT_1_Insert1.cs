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
    public class R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVIMENTO_VGAP
            VALUES ( :PROPOVA-NUM-APOLICE
            ,:PROPOVA-COD-SUBGRUPO
            ,:PROPOVA-COD-FONTE
            ,:WS-NUM-PROPOSTA-AUT
            , '1'
            ,:PROPOVA-NUM-CERTIFICADO
            , ' '
            , '4'
            ,:PROPOVA-COD-CLIENTE
            , 0
            , 0
            , 0
            , 0
            , 0
            , 'S'
            , 'S'
            ,:OPCPAGVI-PERI-PAGAMENTO
            , 12
            , ' '
            , ' '
            , ' '
            , 0
            , ' '
            ,:PROPOVA-OCOREND
            ,:PROPOVA-OCOREND
            , 104
            ,:PROPOVA-AGE-COBRANCA
            , ' '
            , 0
            ,:OPCPAGVI-NUM-CONTA-DEBITO
            ,:W-DIG-CONTA
            , 0
            , ' '
            , '1'
            , 0
            , 0
            , 0
            , 0
            , 0
            , 0
            , 0
            , 0
            , 0
            , 0
            , 0
            ,:MOVIMVGA-IMP-MORNATU-ANT
            ,:MOVIMVGA-IMP-MORNATU-ATU
            ,:MOVIMVGA-IMP-MORACID-ANT
            ,:MOVIMVGA-IMP-MORACID-ATU
            ,:MOVIMVGA-IMP-INVPERM-ANT
            ,:MOVIMVGA-IMP-INVPERM-ATU
            ,:MOVIMVGA-IMP-AMDS-ANT
            ,:MOVIMVGA-IMP-AMDS-ATU
            ,:MOVIMVGA-IMP-DH-ANT
            ,:MOVIMVGA-IMP-DH-ATU
            ,:MOVIMVGA-IMP-DIT-ANT
            ,:MOVIMVGA-IMP-DIT-ATU
            ,:MOVIMVGA-PRM-VG-ANT
            ,:MOVIMVGA-PRM-VG-ATU
            ,:MOVIMVGA-PRM-AP-ANT
            ,:MOVIMVGA-PRM-AP-ATU
            , 895
            ,:SISTEMAS-DTMOV-ABERTO
            , 0
            , '1'
            , 'VE0123B'
            ,:SISTEMAS-DTMOV-ABERTO
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            ,:WS-DTANIVERS
            , NULL
            , ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMENTO_VGAP VALUES ( {FieldThreatment(this.PROPOVA_NUM_APOLICE)} ,{FieldThreatment(this.PROPOVA_COD_SUBGRUPO)} ,{FieldThreatment(this.PROPOVA_COD_FONTE)} ,{FieldThreatment(this.WS_NUM_PROPOSTA_AUT)} , '1' ,{FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)} , ' ' , '4' ,{FieldThreatment(this.PROPOVA_COD_CLIENTE)} , 0 , 0 , 0 , 0 , 0 , 'S' , 'S' ,{FieldThreatment(this.OPCPAGVI_PERI_PAGAMENTO)} , 12 , ' ' , ' ' , ' ' , 0 , ' ' ,{FieldThreatment(this.PROPOVA_OCOREND)} ,{FieldThreatment(this.PROPOVA_OCOREND)} , 104 ,{FieldThreatment(this.PROPOVA_AGE_COBRANCA)} , ' ' , 0 ,{FieldThreatment(this.OPCPAGVI_NUM_CONTA_DEBITO)} ,{FieldThreatment(this.W_DIG_CONTA)} , 0 , ' ' , '1' , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,{FieldThreatment(this.MOVIMVGA_IMP_MORNATU_ANT)} ,{FieldThreatment(this.MOVIMVGA_IMP_MORNATU_ATU)} ,{FieldThreatment(this.MOVIMVGA_IMP_MORACID_ANT)} ,{FieldThreatment(this.MOVIMVGA_IMP_MORACID_ATU)} ,{FieldThreatment(this.MOVIMVGA_IMP_INVPERM_ANT)} ,{FieldThreatment(this.MOVIMVGA_IMP_INVPERM_ATU)} ,{FieldThreatment(this.MOVIMVGA_IMP_AMDS_ANT)} ,{FieldThreatment(this.MOVIMVGA_IMP_AMDS_ATU)} ,{FieldThreatment(this.MOVIMVGA_IMP_DH_ANT)} ,{FieldThreatment(this.MOVIMVGA_IMP_DH_ATU)} ,{FieldThreatment(this.MOVIMVGA_IMP_DIT_ANT)} ,{FieldThreatment(this.MOVIMVGA_IMP_DIT_ATU)} ,{FieldThreatment(this.MOVIMVGA_PRM_VG_ANT)} ,{FieldThreatment(this.MOVIMVGA_PRM_VG_ATU)} ,{FieldThreatment(this.MOVIMVGA_PRM_AP_ANT)} ,{FieldThreatment(this.MOVIMVGA_PRM_AP_ATU)} , 895 ,{FieldThreatment(this.SISTEMAS_DTMOV_ABERTO)} , 0 , '1' , 'VE0123B' ,{FieldThreatment(this.SISTEMAS_DTMOV_ABERTO)} , NULL , NULL , NULL , NULL , NULL ,{FieldThreatment(this.WS_DTANIVERS)} , NULL , ' ' )";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string WS_NUM_PROPOSTA_AUT { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string W_DIG_CONTA { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ANT { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ATU { get; set; }
        public string MOVIMVGA_IMP_MORACID_ANT { get; set; }
        public string MOVIMVGA_IMP_MORACID_ATU { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ANT { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ATU { get; set; }
        public string MOVIMVGA_IMP_AMDS_ANT { get; set; }
        public string MOVIMVGA_IMP_AMDS_ATU { get; set; }
        public string MOVIMVGA_IMP_DH_ANT { get; set; }
        public string MOVIMVGA_IMP_DH_ATU { get; set; }
        public string MOVIMVGA_IMP_DIT_ANT { get; set; }
        public string MOVIMVGA_IMP_DIT_ATU { get; set; }
        public string MOVIMVGA_PRM_VG_ANT { get; set; }
        public string MOVIMVGA_PRM_VG_ATU { get; set; }
        public string MOVIMVGA_PRM_AP_ANT { get; set; }
        public string MOVIMVGA_PRM_AP_ATU { get; set; }
        public string SISTEMAS_DTMOV_ABERTO { get; set; }
        public string WS_DTANIVERS { get; set; }

        public static void Execute(R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1 r2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}