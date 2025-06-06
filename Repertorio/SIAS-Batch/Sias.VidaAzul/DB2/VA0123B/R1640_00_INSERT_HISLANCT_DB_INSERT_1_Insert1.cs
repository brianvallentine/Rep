using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1 : QueryBasis<R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTAVA
            (NRCERTIF ,
            NRPARCEL ,
            OCORRHISTCTA ,
            AGECTADEB ,
            OPRCTADEB ,
            NUMCTADEB ,
            DIGCTADEB ,
            DTVENCTO ,
            VLPRMTOT ,
            SITUACAO ,
            TIPLANC ,
            TIMESTAMP ,
            OCORHIST ,
            CODCONV ,
            NSAS ,
            NSL ,
            NSAC ,
            CODRET ,
            CODUSU ,
            NUM_CARTAO_CREDITO)
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :PARCEVID-NUM-PARCELA1,
            1,
            :OPCPAGVI-COD-AGENCIA-DEBITO,
            :OPCPAGVI-OPE-CONTA-DEBITO,
            :OPCPAGVI-NUM-CONTA-DEBITO,
            :OPCPAGVI-DIG-CONTA-DEBITO,
            :PROPOVA-DTPROXVEN ,
            :PLAVAVGA-VLPREMIOTOT,
            '0' ,
            '1' ,
            CURRENT TIMESTAMP,
            0,
            :WHOST-COD-CONVENIO,
            NULL,
            NULL,
            NULL,
            NULL,
            'VA0123B' ,
            :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUMCAR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.PARCEVID_NUM_PARCELA1)}, 1, {FieldThreatment(this.OPCPAGVI_COD_AGENCIA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_OPE_CONTA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_NUM_CONTA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_DIG_CONTA_DEBITO)}, {FieldThreatment(this.PROPOVA_DTPROXVEN)} , {FieldThreatment(this.PLAVAVGA_VLPREMIOTOT)}, '0' , '1' , CURRENT TIMESTAMP, 0, {FieldThreatment(this.WHOST_COD_CONVENIO)}, NULL, NULL, NULL, NULL, 'VA0123B' ,  {FieldThreatment((this.VIND_NUMCAR?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CARTAO_CREDITO))})";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA1 { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string WHOST_COD_CONVENIO { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_NUMCAR { get; set; }

        public static void Execute(R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1 r1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1)
        {
            var ths = r1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}