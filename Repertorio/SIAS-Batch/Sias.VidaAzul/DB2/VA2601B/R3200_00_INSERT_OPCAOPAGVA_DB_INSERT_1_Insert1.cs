using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 : QueryBasis<R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1>
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
            :WHOST-OPCAOPAG,
            :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO,
            'VA2601B' ,
            CURRENT TIMESTAMP,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB
            :VIND-AGECTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB
            :VIND-OPRCTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB
            :VIND-NUMCTADEB,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB
            :VIND-DIGCTADEB,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.PROPOFID_DTQITBCO)}, '9999-12-31' , {FieldThreatment(this.WHOST_OPCAOPAG)}, {FieldThreatment(this.PRODUVG_PERI_PAGAMENTO)} , {FieldThreatment(this.PROPOFID_DIA_DEBITO)}, 'VA2601B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_AGECTADEB?.ToInt() == -1 ? null : this.PROPOFID_AGECTADEB))},  {FieldThreatment((this.VIND_OPRCTADEB?.ToInt() == -1 ? null : this.PROPOFID_OPRCTADEB))},  {FieldThreatment((this.VIND_NUMCTADEB?.ToInt() == -1 ? null : this.PROPOFID_NUMCTADEB))},  {FieldThreatment((this.VIND_DIGCTADEB?.ToInt() == -1 ? null : this.PROPOFID_DIGCTADEB))}, NULL)";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string WHOST_OPCAOPAG { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PROPOFID_DIA_DEBITO { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string VIND_DIGCTADEB { get; set; }

        public static void Execute(R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1)
        {
            var ths = r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}