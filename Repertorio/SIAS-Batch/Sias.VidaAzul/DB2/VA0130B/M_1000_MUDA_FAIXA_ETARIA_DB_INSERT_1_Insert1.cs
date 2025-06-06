using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 : QueryBasis<M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COBERPROPVA
            ( NRCERTIF
            ,OCORHIST
            ,DTINIVIG
            ,DTTERVIG
            ,IMPSEGUR
            ,QUANT_VIDAS
            ,IMPSEGIND
            ,CODOPER
            ,OPCAO_COBER
            ,IMPMORNATU
            ,IMPMORACID
            ,IMPINVPERM
            ,IMPAMDS
            ,IMPDH
            ,IMPDIT
            ,VLPREMIO
            ,PRMVG
            ,PRMAP
            ,QTTITCAP
            ,VLTITCAP
            ,VLCUSTCAP
            ,IMPSEGCDC
            ,VLCUSTCDG
            ,CODUSU
            ,TIMESTAMP
            ,IMPSEGAUXF
            ,VLCUSTAUXF
            ,PRMDIT
            ,QTDIT )
            VALUES (:PROPVA-NRCERTIF,
            :PROPVA-OCORHIST,
            DATE(:COBERP-DTINIVIG) + 1 DAY ,
            '9999-12-31' ,
            :COBERP-IMPMORNATU-ANT,
            1,
            :COBERP-IMPMORNATU-ANT,
            820,
            :PROPVA-OPCAO-COBER,
            :COBERP-IMPMORNATU-ANT,
            :COBERP-IMPMORACID-ANT,
            :COBERP-IMPINVPERM-ANT,
            :COBERP-IMPAMDS-ANT,
            :COBERP-IMPDH-ANT,
            :COBERP-IMPDIT-ANT,
            :COBERP-PRMVG-ATU,
            :COBERP-PRMVG-ATU,
            :COBERP-PRMAP-ANT,
            :COBERP-QTTITCAP,
            :COBERP-VLTITCAP,
            :COBERP-VLCUSTCAP,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            'VA0130B' ,
            CURRENT TIMESTAMP,
            :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I,
            :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I,
            :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I,
            :COBERP-QTDIT:COBERP-QTDIT-I)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERPROPVA ( NRCERTIF ,OCORHIST ,DTINIVIG ,DTTERVIG ,IMPSEGUR ,QUANT_VIDAS ,IMPSEGIND ,CODOPER ,OPCAO_COBER ,IMPMORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMVG ,PRMAP ,QTTITCAP ,VLTITCAP ,VLCUSTCAP ,IMPSEGCDC ,VLCUSTCDG ,CODUSU ,TIMESTAMP ,IMPSEGAUXF ,VLCUSTAUXF ,PRMDIT ,QTDIT ) VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.PROPVA_OCORHIST)}, DATE({FieldThreatment(this.COBERP_DTINIVIG)}) + 1 DAY , '9999-12-31' , {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, 1, {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, 820, {FieldThreatment(this.PROPVA_OPCAO_COBER)}, {FieldThreatment(this.COBERP_IMPMORNATU_ANT)}, {FieldThreatment(this.COBERP_IMPMORACID_ANT)}, {FieldThreatment(this.COBERP_IMPINVPERM_ANT)}, {FieldThreatment(this.COBERP_IMPAMDS_ANT)}, {FieldThreatment(this.COBERP_IMPDH_ANT)}, {FieldThreatment(this.COBERP_IMPDIT_ANT)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.COBERP_PRMAP_ANT)}, {FieldThreatment(this.COBERP_QTTITCAP)}, {FieldThreatment(this.COBERP_VLTITCAP)}, {FieldThreatment(this.COBERP_VLCUSTCAP)}, {FieldThreatment(this.COBERP_IMPSEGCDG)}, {FieldThreatment(this.COBERP_VLCUSTCDG)}, 'VA0130B' , CURRENT TIMESTAMP,  {FieldThreatment((this.COBERP_IMPSEGAUXF_I?.ToInt() == -1 ? null : this.COBERP_IMPSEGAUXF))},  {FieldThreatment((this.COBERP_VLCUSTAUXF_I?.ToInt() == -1 ? null : this.COBERP_VLCUSTAUXF))},  {FieldThreatment((this.COBERP_PRMDIT_I?.ToInt() == -1 ? null : this.COBERP_PRMDIT_ANT))},  {FieldThreatment((this.COBERP_QTDIT_I?.ToInt() == -1 ? null : this.COBERP_QTDIT))})";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string COBERP_DTINIVIG { get; set; }
        public string COBERP_IMPMORNATU_ANT { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string COBERP_IMPMORACID_ANT { get; set; }
        public string COBERP_IMPINVPERM_ANT { get; set; }
        public string COBERP_IMPAMDS_ANT { get; set; }
        public string COBERP_IMPDH_ANT { get; set; }
        public string COBERP_IMPDIT_ANT { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string COBERP_PRMAP_ANT { get; set; }
        public string COBERP_QTTITCAP { get; set; }
        public string COBERP_VLTITCAP { get; set; }
        public string COBERP_VLCUSTCAP { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IMPSEGAUXF_I { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_VLCUSTAUXF_I { get; set; }
        public string COBERP_PRMDIT_ANT { get; set; }
        public string COBERP_PRMDIT_I { get; set; }
        public string COBERP_QTDIT { get; set; }
        public string COBERP_QTDIT_I { get; set; }

        public static void Execute(M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 m_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1)
        {
            var ths = m_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}