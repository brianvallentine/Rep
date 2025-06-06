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
    public class R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 : QueryBasis<R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIS_COBER_PROPOST
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            1,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO,
            '9999-12-31' ,
            :DCLPLANOS-VA-VGAP.IMPMORNATU,
            0,
            :DCLPLANOS-VA-VGAP.IMPMORNATU,
            106,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER,
            :DCLPLANOS-VA-VGAP.IMPMORNATU,
            :DCLPLANOS-VA-VGAP.IMPMORACID,
            :DCLPLANOS-VA-VGAP.IMPINVPERM,
            :DCLPLANOS-VA-VGAP.IMPAMDS,
            :DCLPLANOS-VA-VGAP.IMPDH,
            :DCLPLANOS-VA-VGAP.IMPDIT,
            :DCLPLANOS-VA-VGAP.VLPREMIOTOT,
            :DCLPLANOS-VA-VGAP.PRMVG,
            :DCLPLANOS-VA-VGAP.PRMAP,
            :DCLPLANOS-VA-VGAP.QTTITCAP,
            :DCLPLANOS-VA-VGAP.VLTITCAP,
            :DCLPLANOS-VA-VGAP.VLCUSTCAP,
            :DCLPLANOS-VA-VGAP.IMPSEGCDG,
            :DCLPLANOS-VA-VGAP.VLCUSTCDG,
            'VA2601B' ,
            CURRENT TIMESTAMP,
            :DCLPLANOS-VA-VGAP.IMPSEGAUXF
            :VIND-IMPSEGAUXF,
            :DCLPLANOS-VA-VGAP.VLCUSTAUXF
            :VIND-VLCUSTAUXF,
            :DCLPLANOS-VA-VGAP.PRMDIT
            :VIND-PRMDIT,
            :DCLPLANOS-VA-VGAP.QTDIT
            :VIND-QTDIT)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIS_COBER_PROPOST VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, 1, {FieldThreatment(this.PROPOFID_DTQITBCO)}, '9999-12-31' , {FieldThreatment(this.IMPMORNATU)}, 0, {FieldThreatment(this.IMPMORNATU)}, 106, {FieldThreatment(this.PROPOFID_OPCAO_COBER)}, {FieldThreatment(this.IMPMORNATU)}, {FieldThreatment(this.IMPMORACID)}, {FieldThreatment(this.IMPINVPERM)}, {FieldThreatment(this.IMPAMDS)}, {FieldThreatment(this.IMPDH)}, {FieldThreatment(this.IMPDIT)}, {FieldThreatment(this.VLPREMIOTOT)}, {FieldThreatment(this.PRMVG)}, {FieldThreatment(this.PRMAP)}, {FieldThreatment(this.QTTITCAP)}, {FieldThreatment(this.VLTITCAP)}, {FieldThreatment(this.VLCUSTCAP)}, {FieldThreatment(this.IMPSEGCDG)}, {FieldThreatment(this.VLCUSTCDG)}, 'VA2601B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_IMPSEGAUXF?.ToInt() == -1 ? null : this.IMPSEGAUXF))},  {FieldThreatment((this.VIND_VLCUSTAUXF?.ToInt() == -1 ? null : this.VLCUSTAUXF))},  {FieldThreatment((this.VIND_PRMDIT?.ToInt() == -1 ? null : this.PRMDIT))},  {FieldThreatment((this.VIND_QTDIT?.ToInt() == -1 ? null : this.QTDIT))})";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string IMPMORNATU { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string IMPMORACID { get; set; }
        public string IMPINVPERM { get; set; }
        public string IMPAMDS { get; set; }
        public string IMPDH { get; set; }
        public string IMPDIT { get; set; }
        public string VLPREMIOTOT { get; set; }
        public string PRMVG { get; set; }
        public string PRMAP { get; set; }
        public string QTTITCAP { get; set; }
        public string VLTITCAP { get; set; }
        public string VLCUSTCAP { get; set; }
        public string IMPSEGCDG { get; set; }
        public string VLCUSTCDG { get; set; }
        public string IMPSEGAUXF { get; set; }
        public string VIND_IMPSEGAUXF { get; set; }
        public string VLCUSTAUXF { get; set; }
        public string VIND_VLCUSTAUXF { get; set; }
        public string PRMDIT { get; set; }
        public string VIND_PRMDIT { get; set; }
        public string QTDIT { get; set; }
        public string VIND_QTDIT { get; set; }

        public static void Execute(R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1)
        {
            var ths = r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}