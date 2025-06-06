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
    public class R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 : QueryBasis<R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL
            VALUES ( :OPCPAGVI-NUM-CERTIFICADO
            ,:OPCPAGVI-DATA-INIVIGENCIA
            ,:OPCPAGVI-DATA-TERVIGENCIA
            ,:OPCPAGVI-OPCAO-PAGAMENTO
            ,:OPCPAGVI-PERI-PAGAMENTO
            ,:OPCPAGVI-DIA-DEBITO
            ,:OPCPAGVI-COD-USUARIO
            , CURRENT TIMESTAMP
            ,:OPCPAGVI-COD-AGENCIA-DEBITO :VIND-AGEDEB
            ,:OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB
            ,:OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB
            ,:OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB
            ,:OPCPAGVI-NUM-CARTAO-CREDITO :VIND-NUMCAR )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES ( {FieldThreatment(this.OPCPAGVI_NUM_CERTIFICADO)} ,{FieldThreatment(this.OPCPAGVI_DATA_INIVIGENCIA)} ,{FieldThreatment(this.OPCPAGVI_DATA_TERVIGENCIA)} ,{FieldThreatment(this.OPCPAGVI_OPCAO_PAGAMENTO)} ,{FieldThreatment(this.OPCPAGVI_PERI_PAGAMENTO)} ,{FieldThreatment(this.OPCPAGVI_DIA_DEBITO)} ,{FieldThreatment(this.OPCPAGVI_COD_USUARIO)} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_AGEDEB?.ToInt() == -1 ? null : this.OPCPAGVI_COD_AGENCIA_DEBITO))} , {FieldThreatment((this.VIND_OPEDEB?.ToInt() == -1 ? null : this.OPCPAGVI_OPE_CONTA_DEBITO))} , {FieldThreatment((this.VIND_CTADEB?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CONTA_DEBITO))} , {FieldThreatment((this.VIND_DIGDEB?.ToInt() == -1 ? null : this.OPCPAGVI_DIG_CONTA_DEBITO))} , {FieldThreatment((this.VIND_NUMCAR?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CARTAO_CREDITO))} )";

            return query;
        }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }
        public string OPCPAGVI_DATA_INIVIGENCIA { get; set; }
        public string OPCPAGVI_DATA_TERVIGENCIA { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_USUARIO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGEDEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPEDEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_CTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGDEB { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_NUMCAR { get; set; }

        public static void Execute(R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 r8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1)
        {
            var ths = r8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}