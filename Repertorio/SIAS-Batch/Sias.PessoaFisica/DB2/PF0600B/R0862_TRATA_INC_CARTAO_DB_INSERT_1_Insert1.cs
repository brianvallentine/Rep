using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1 : QueryBasis<R0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.OPCAO_PAG_VIDAZUL
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO,
            '9999-12-31' ,
            'C' ,
            :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO,
            'PF0600B' ,
            CURRENT TIMESTAMP,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB ,
            :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPRCTADEB ,
            :OPCPAGVI-NUM-CONTA-DEBITO :VIND-NUMCTADEB ,
            :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGCTADEB ,
            :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.PROPOFID_DTQITBCO)}, '9999-12-31' , 'C' , {FieldThreatment(this.PRODUVG_PERI_PAGAMENTO)} , {FieldThreatment(this.PROPOFID_DIA_DEBITO)}, 'PF0600B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_AGECTADEB?.ToInt() == -1 ? null : this.OPCPAGVI_COD_AGENCIA_DEBITO))} ,  {FieldThreatment((this.VIND_OPRCTADEB?.ToInt() == -1 ? null : this.OPCPAGVI_OPE_CONTA_DEBITO))} ,  {FieldThreatment((this.VIND_NUMCTADEB?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CONTA_DEBITO))} ,  {FieldThreatment((this.VIND_DIGCTADEB?.ToInt() == -1 ? null : this.OPCPAGVI_DIG_CONTA_DEBITO))} ,  {FieldThreatment((this.VIND_CARTAO?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CARTAO_CREDITO))} )";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PROPOFID_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_CARTAO { get; set; }

        public static void Execute(R0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1 r0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1)
        {
            var ths = r0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}